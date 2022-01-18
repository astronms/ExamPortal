using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExamPortal.Data.Users;
using ExamPortal.IRepository;
using ExamPortal.Models.Exam;
using ExamPortal.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExamPortal.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(UserManager<User> userManager, ILogger<StudentController> logger,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{guid:Guid}", Name = "GetStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudent(Guid guid)
        {
            var user = await _unitOfWork.Users.Get(q => q.Id == guid.ToString(),q => q.Include(x =>x.StudentInfo));
            var isStudent = await (_userManager.IsInRoleAsync(user, "User"));
            if (isStudent)
            {
                var result = _mapper.Map<UserDTO>(user);
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var users = await _unitOfWork.Users.GetAll(include:q=>q.Include(x=>x.StudentInfo));
                IList<User> students = new List<User>();
                foreach (var user in users)
                {
                    var isStudent = await _userManager.IsInRoleAsync(user, "User");
                    if (isStudent)
                    {
                        students.Add(user);
                    }
                }
                var results = _mapper.Map<IList<UserDTO>>(students);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetStudent)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }
    }
}
