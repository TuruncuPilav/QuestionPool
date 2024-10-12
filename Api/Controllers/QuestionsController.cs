using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core.Repositories.Classes;
using Core.Data.Entity;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize(Roles = "admin")]
    public class QuestionsController : Controller
    {
        private readonly QuestionRepository q;

        public QuestionsController()
        {
            q = new QuestionRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(q.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(q.GetById(id));
        }

        [HttpGet("library/{libraryId}")]
        public IActionResult GetByLibraryId(int libraryId)
        {
            return Ok(q.GetByLibraryId(libraryId));
        }

        [HttpGet("member/{memberId}")]
        public IActionResult GetByMemberId(int memberId)
        {
            return Ok(q.GetByMemberId(memberId));
        }

        [HttpGet("type/{type}")]
        public IActionResult GetByType(int type)
        {
            return Ok(q.GetByType(type));
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Question question)
        {
            q.Set(question);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Set([FromBody] Question question)
        {
            q.Set(question);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            q.Remove(id);
            return Ok();
        }
    }
}