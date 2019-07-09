using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SRP.Models;

namespace SRP.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PersonController : ControllerBase
    {
        public List<Person> People { get; set; }
        public PersonController(List<Person> people)
        {
            People = people;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return Ok(People);
        }
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Person> Get(int id)
        {
            if (id < 0)
            {
                return NotFound($"cannot find any person with id {id}");
            }            
            Person? person = People?[id];
            return Ok(person);
        }
    }
}