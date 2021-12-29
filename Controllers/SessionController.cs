using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using ExamPortal.Data.ExamData;
using ExamPortal.IRepository;
using ExamPortal.Models.Exam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ExamPortal.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class SessionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SessionController> _logger;
        private readonly IMapper _mapper;

        public SessionController(IUnitOfWork unitOfWork, ILogger<SessionController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{guid:Guid}", Name = "GetSession")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSession(Guid guid)
        {
            var session = await _unitOfWork.Sessions.Get(q => q.SessionId == guid);
            var result = _mapper.Map<SessionDTO>(session);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSessions()
        {
            try
            {
                var sessions = await _unitOfWork.Sessions.GetAll();
                var results = _mapper.Map<IList<SessionDTO>>(sessions);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetSessions)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSession([FromBody] SessionDTO sessionDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateSession)}");
                return BadRequest(ModelState);
            }

            var session = _mapper.Map<Session>(sessionDTO);
            await _unitOfWork.Sessions.Insert(session);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetSession", new { id = session.SessionId}, session);
        }

        [HttpDelete("{guid:Guid}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSession(Guid guid)
        {
            if (guid != Guid.Empty)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteSession)}");
                return BadRequest();
            }

            var country = await _unitOfWork.Sessions.Get(q => q.SessionId == guid);
            if (country == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteSession)}");
                return BadRequest("Submitted data is invalid");
            }

            await _unitOfWork.Sessions.Delete(guid);
            await _unitOfWork.Save();

            return NoContent();

        }
    }
}
