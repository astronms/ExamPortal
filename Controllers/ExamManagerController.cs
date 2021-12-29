using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ExamPortal.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ExamPortal.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class ExamManagerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ExamManagerController> _logger;

        //[HttpGet("{id:int}", Name = "GetSession")]
        //public async Task<IActionResult> GetSession(Guid id)
        //{
        //    //throw new Exception("Error message");
        //    //var session = await _unitOfWork.Sessions.Get(q => q.Id ==id);
        //    ////mapper
        //    //var result = true;
        //    //return Ok(result);
        //}

        //[Authorize(Roles = "Administrator")]
        //[HttpPost]
        //public async Task<ActionResult<Session>> CreateExam(Session session)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        _logger.LogError($"Invalid POST attempt in {nameof(CreateExam)}");
        //        return BadRequest(ModelState);
        //    }



        //    return CreatedAtAction("GetSession", new { id = Session.Id }, session);
        //}
    }
}
