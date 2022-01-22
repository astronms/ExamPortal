using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ExamPortal.IRepository;
using ExamPortal.Models.Exam;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ExamPortal.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class ExamController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ExamController> _logger;
        private readonly IMapper _mapper;

        public ExamController(IUnitOfWork unitOfWork, ILogger<ExamController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet("{guid:Guid}", Name = "GetExam")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetExam(Guid guid)
        {
            var exam = await _unitOfWork.Exams.Get(q => q.ExamId == guid);
            var result = _mapper.Map<ExamDTO>(exam);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetExams()
        {
            try
            {
                var exams = await _unitOfWork.Sessions.GetAll();
                var results = _mapper.Map<IList<ExamDTO>>(exams);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetExam)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

    }
}
