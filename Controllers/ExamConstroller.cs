using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

using ExamPortal.Models;
using System.Threading;

namespace ExamPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private IMemoryCache _cache;

        public ExamController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        private static readonly string[] Titles = new[]
        {
            "PAA 1", "AKO 2", "WK 1", "POMOCY KOLEJNY EGZAMIN", "PG COS TAM", "KOLEJNY EXAMIN"
        };

        private static readonly List<QuestionModel> Questions = new List<QuestionModel>
        {
            new QuestionModel{
                Id = 19,
                Content = "Amstafa zaliczamy do:",
                Time = 60,
                Answers = new AnswerModel[]{ new AnswerModel{ Id=1, Content="Kotów", SelectedOption = false}, new AnswerModel{ Id=2, Content="Psów", SelectedOption = false}}
            },
            new QuestionModel{
                Id = 20,
                Content = "Frameworkiem PHP nie jest:",
                Time = 60,
                Answers = new AnswerModel[]{ new AnswerModel{ Id=1, Content="React", SelectedOption = false}, new AnswerModel{ Id=2, Content="Symfony", SelectedOption = false}}
            },
            new QuestionModel{
                Id = 21,
                Content = "Iomiona głownych postaci z bajki Sąsiedzi to:",
                Time = 60,
                Answers = new AnswerModel[]{ new AnswerModel{ Id=1, Content="Pat i Mat", SelectedOption = false}, new AnswerModel{ Id=2, Content="Piotr i Paweł", SelectedOption = false}}
            }    
        };

        // GET api/values
        [HttpGet, Authorize, Route("getlist")]
        public IEnumerable<ExamModel> getlist()
        {
            var rng = new Random();
            return Enumerable.Range(1, 4).Select(index => new ExamModel
            {
                Id = rng.Next(0, 1000),
                Title = Titles[rng.Next(Titles.Length)],
                Duration = rng.Next(0, 1000),
                QuestionsNumber = rng.Next(10, 30), 
                StartDate = DateTime.Now, 
                Available = true
            })
            .ToArray();
        }

        [HttpGet("id"), Authorize, Route("start")]
        public bool startExam(int id)
        {
            System.IO.File.Delete("state.txt");
            return true;
        }

        [HttpGet, Authorize, Route("getquestion")]
        public IActionResult getNextQuestion()
        {
            if(!System.IO.File.Exists("state.txt"))
            {
                var state = new Dictionary<string, string>();
                state.Add("question_number", "0");
                state.Add("question_id", Questions[0].Id.ToString());
                state.Add("time_start", "");
                state.Add("answered", "false");
                this.saveState(state);
                var reply = new GetQuestionReplyModel();
                reply.ExamQuestionQuantity = 3;
                reply.CurrentQuestionNumber = 1;
                reply.LeftTime = Questions[0].Time;
                reply.Question = Questions[0];
                return Ok(reply);
            }
            else
            {
                var state = this.readState();
                if(state["answered"] == "true" || Convert.ToInt64(state["time_start"]) + Questions[Int32.Parse(state["question_number"])].Time <= new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()) {
                    int next_question = Int32.Parse(state["question_number"]) + 1;
                    if(next_question < 3)
                    {
                        state["question_number"] = next_question.ToString();
                        state["question_id"] = Questions[next_question].Id.ToString();
                        state["time_start"] = "";
                        state["answered"] = "false";
                        this.saveState(state);
                        var reply = new GetQuestionReplyModel();
                        reply.ExamQuestionQuantity = 3;
                        reply.CurrentQuestionNumber = next_question + 1;
                        reply.LeftTime = Questions[next_question].Time;
                        reply.Question = Questions[next_question];
                        return Ok(reply);
                    }
                    return BadRequest("Exam already passed.");
                }
                else {
                    var reply = new GetQuestionReplyModel();
                    reply.ExamQuestionQuantity = 3;
                    reply.CurrentQuestionNumber = Int32.Parse(state["question_number"]) + 1;
                    reply.LeftTime = Convert.ToInt32(Convert.ToInt64(state["time_start"]) + Questions[Int32.Parse(state["question_number"])].Time - new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
                    reply.Question = Questions[Int32.Parse(state["question_number"])];
                    return Ok(reply);
                }
            }
        }

        [HttpGet("id"), Authorize, Route("saveanswers")]
        public IActionResult saveAnswers(int id) {
            CancellationTokenSource token = null;
            if(this._cache.TryGetValue("_cancelToken", out token))
            {
                //Console.WriteLine(token);
                token.Cancel();
                var state = this.readState();
                state["answered"] = "true";
                this.saveState(state);
                return Ok();
            }
            return BadRequest("No pennding question.");
        }

        [HttpGet("id"), Authorize, Route("timer")]
        public async Task<IActionResult> runTimer(int id) {
            
            //Update czasu wystartowania czasu pytania
            var state = this.readState();

            if(state["question_id"] != id.ToString())
            {
                return BadRequest();
            }
            if(state["time_start"] == "") {
                state["time_start"] = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString();
                this.saveState(state);
            }

            //Obliczanie czasu na pytanie. 
            int left_time = Convert.ToInt32(Convert.ToInt64(state["time_start"]) + 60 - new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());

            //Cancellation token potrzebny aby zamknąć Task w przypadku wcześniejszej odpowiedzi na pytanie 
            CancellationTokenSource token = new CancellationTokenSource();
            this._cache.Set("_cancelToken", token); //Zapisujemy do cache. Uwaga! To powinno być per user!
            try {
                await Task.Delay(left_time * 1000, token.Token);
                return await Task.FromResult(Ok());
            }
            catch(TaskCanceledException ae)
            {
                return Ok(); //W przypadku kiedy przerwaliśmy Task zwracamy, że czas pytania się skończył dzięki czemu triggerujemy pobranie następnego pytania. 
            }
        }

        //Za tą linią same haksy! Nie ruszać bo pojawią się hazardy w dostępie do pliku, który i tak jest rozwiązaniem tymczasowym. ;) 
        private Dictionary<string, string> readState()
        {
            string json = "";
            FileStream fs = new FileStream("state.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            json = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        private void saveState(Dictionary<string, string> state)
        {
            StreamWriter writetext = new StreamWriter("state.txt");
            writetext.WriteLine(JsonConvert.SerializeObject( state ));
            writetext.Close();
        }
    }

}
