using Microsoft.AspNetCore.Mvc;
using Core.Repositories.Classes;
using System.Text.Json;
using Core.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Core.Data.Core;
using System.Data.Entity.Infrastructure;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize(Roles = "admin")]
    public class MembersController : ControllerBase
    {
        private readonly MemberRepository m;
        public MembersController()
        {
            m = new MemberRepository();
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var members = await m.Get();
            return Ok(members);
        }

        // [HttpGet("all")]
        // public IActionResult GetAll()
        // {
        //     return Ok(m.GetAll());
        // }

        // [HttpGet("deleted")]
        // public IActionResult GetDeleted()
        // {
        //     return Ok(m.GetDeleted());
        // }

        [HttpGet("{id}")]
        public async Task<ActionResult> TFindById(int id)
        {
            return Ok(await m.FindById(id));
        }

        // [HttpGet("name/{name}")]
        // public IActionResult GetByName(string name, [FromQuery] string? surname = null)
        // {
        //     return Ok(m.GetByName(name, surname));
        // }

        // [HttpPost]
        // public IActionResult Add([FromBody] Member member)
        // {
        //     m.Set(member);
        //     return Ok();
        // }

        // [HttpPut("{id}")]
        // public IActionResult Update(int id, [FromBody] Member member)
        // {
        //     if(member == null)
        //         return BadRequest();

        //     var selectedMember = m.GetById(id);
        //     if (selectedMember == null)
        //         return NotFound();

        //     m.Set(member);
        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public IActionResult Remove(int id)
        // {
        //     return Ok();
        // }
    }
}
