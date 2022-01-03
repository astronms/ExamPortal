using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ExamPortal.Data;
using ExamPortal.IRepository;
using ExamPortal.Models;
using ExamPortal.Models.Exam;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExamPortal.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CourseController> _logger;
        private readonly IMapper _mapper;

        public CourseController(IUnitOfWork unitOfWork, ILogger<CourseController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{guid:Guid}", Name = "GetCourse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCourse(Guid guid)
        {
            var course = await _unitOfWork.Courses.Get(q => q.CourseId == guid, include: q => q.Include(x => x.Users));
            var result = _mapper.Map<CourseDTO>(course);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCourse()
        {
            try
            {
                var courses = await _unitOfWork.Courses.GetAll(include: q => q.Include(x => x.Users));
                var results = _mapper.Map<IList<CourseDTO>>(courses);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetCourse)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseDTO courseDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateCourse)}");
                return BadRequest(ModelState);
            }

            var course = _mapper.Map<Course>(courseDTO);
            await _unitOfWork.Courses.Insert(course);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetCourse", new { guid = course.CourseId }, course);

        }

        [HttpPut("{guid:Guid}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCourse(Guid guid, [FromBody] UpdateCoruseDTO courseDTO)
        {
            if (!ModelState.IsValid || guid != Guid.Empty)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateCourse)}");
                return BadRequest(ModelState);
            }

            var course = await _unitOfWork.Courses.Get(q => q.CourseId== guid);
            if (course == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateCourse)}");
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(courseDTO, course);
            _unitOfWork.Courses.Update(course);
            await _unitOfWork.Save();

            return NoContent();

        }

        [HttpDelete("{guid:Guid}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCourse(Guid guid)
        {
            if (guid != Guid.Empty)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteCourse)}");
                return BadRequest();
            }

            var course = await _unitOfWork.Courses.Get(q => q.CourseId == guid);
            if (course == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteCourse)}");
                return BadRequest("Submitted data is invalid");
            }

            await _unitOfWork.Courses.Delete(guid);
            await _unitOfWork.Save();

            return NoContent();

        }

    }
}
