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
    public class ExamsController : ControllerBase
    {
        private static readonly string[] Titles = new[]
        {
            "PAA 1", "AKO 2", "WK 1", "POMOCY KOLEJNY EGZAMIN", "PG COS TAM", "KOLEJNY EXAMIN"
        };

        // GET api/values
        [HttpGet, Authorize]
        public IEnumerable<ExamModel> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 4).Select(index => new ExamModel
            {
                Id = rng.Next(0, 1000),
                Title = Titles[rng.Next(Titles.Length)],
                Duration = rng.Next(0, 1000),
                QuestionsNumber = rng.Next(10, 30)
            })
            .ToArray();
        }
    }
}
