using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Entity;
using Core.Repositories.Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize(Roles = "admin")]
    public class LibrariesController : ControllerBase
    {
        private readonly LibraryRepository l;
        public LibrariesController()
        {
            l = new LibraryRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(l.Get());
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(l.GetAll());
        }

        [HttpGet("deleted")]
        public IActionResult GetDeleted()
        {
            return Ok(l.GetDeleted());
        }
 
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(l.GetById(id));
        }

        [HttpGet("member/{memberId}")]
        public IActionResult GetByMemberId(int memberId)
        {
            return Ok(l.GetByMemberId(memberId));
        } 

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            return Ok(l.GetByName(name));
        }
        
        [HttpGet("category/{category}")]
        public IActionResult GetByCategory(string category)
        {
            return Ok(l.GetByCategory(category));
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Library library)
        {
            l.Add(library);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Set([FromBody] Library library)
        {
            l.Set(library);
            return Ok();
        }

        [HttpPost("member/{libraryId}/{memberId}/{role}")]
        public IActionResult SetMember(int memberId, int libraryId, string role)
        {
            l.AddMember(memberId, libraryId, role);
            return Ok();
        }
        
        [HttpPost("member/{memberId}/{newRole}")]
        public IActionResult SetMemberRole(int memberId, string newRole)
        {
            l.SetMemberRole(memberId, newRole);
            return Ok();
        }

        [HttpPost("visibility/{id}")]
        public IActionResult ToggleVisibility(int id)
        {
            l.ToggleVisibility(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            l.Remove(id);
            return Ok();
        }

        [HttpDelete("member/{libraryId}/{memberId}")]
        public IActionResult RemoveMember(int libraryId, int memberId)
        {
            l.RemoveMember(libraryId, memberId);
            return Ok();
        }
    }
}




























        // [HttpGet("{id}")]
        // [AllowAnonymous]
        // public IActionResult GetByInt(int id)
        // {
        //     if (!User.Identity!.IsAuthenticated)
        //     {
        //         return Unauthorized("Erisim Yetkiniz Yok");
        //     }
        //     // Bu noktada yetki kontrollerini kendin yapabilirsin.
        //     // Örneğin burada, "admin" rolüne sahip olup olmadığını kontrol edebilirsin.
        //     // Eğer yetkili değilse, Unauthorized dönüşü yapabilirsin.
        //     return Ok(l.GetById(id));
        // }