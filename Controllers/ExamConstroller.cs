using System.Runtime.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

using ExamPortal.Models;

namespace ExamPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
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
                System.IO.File.WriteAllText("state.txt", JsonConvert.SerializeObject( state ));
                var reply = new GetQuestionReplyModel();
                reply.ExamQuestionQuantity = 3;
                reply.CurrentQuestionNumber = 1;
                reply.LeftTime = Questions[0].Time;
                reply.Question = Questions[0];
                return Ok(reply);
            }
            else
            {
                string json = System.IO.File.ReadAllText("state.txt");
                var state = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                if(state["answered"] == "true" || Convert.ToInt64(state["time_start"]) + Questions[Int32.Parse(state["question_number"])].Time < new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()) {
                    int next_question = Int32.Parse(state["question_number"]) + 1;
                    if(next_question < 3)
                    {
                        state["question_number"] = next_question.ToString();
                        state["question_id"] = Questions[next_question].Id.ToString();
                        state["time_start"] = "";
                        state["answered"] = "false";
                        System.IO.File.WriteAllText("state.txt", JsonConvert.SerializeObject( state ));
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

        [HttpGet("id"), Authorize, Route("starttime")]
        public IActionResult startQuestionTime(int id) {
            string json = System.IO.File.ReadAllText("state.txt");
            var state = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            if(state["question_id"] != id.ToString())
            {
                return BadRequest();
            }
            if(state["time_start"] == "") {
                state["time_start"] = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString();
                System.IO.File.WriteAllText("state.txt", JsonConvert.SerializeObject( state ));
            }
            return Ok();
        }

        [HttpGet("id"), Authorize, Route("saveanswers")]
        public IActionResult saveAnswers(int id) {
            string json = System.IO.File.ReadAllText("state.txt");
            var state = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            state["answered"] = "true";
            System.IO.File.WriteAllText("state.txt", JsonConvert.SerializeObject( state ));
            return Ok();
        }
    }

}
