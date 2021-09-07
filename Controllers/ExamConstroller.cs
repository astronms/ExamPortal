using System.Runtime.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
                StartDate = DateTime.Now
            })
            .ToArray();
        }

        [HttpGet("id"), Authorize, Route("start")]
        public bool startExam(int id)
        {
            return true;
        }

        [HttpGet,Authorize, Route("getquestion")]
        public IActionResult getNextQuestion()
        {
            var rng = new Random();
            return Ok(Questions[rng.Next(Questions.Count)]);
            //return NotFound("Exam already passed.");
        }
    }
}
