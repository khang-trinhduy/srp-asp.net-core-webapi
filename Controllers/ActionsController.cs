using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SRP.Models;

namespace SRP.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ActionsController : ControllerBase
    {
        public List<Person> People { get; set; }
        public List<Models.Action> Actions { get; set; }
        public ActionsController()
        {
            Seed();
        }

        private void Seed()
        {
            People = new List<Person>();
            Actions = new List<Models.Action>();
            var p1 = new Person ("David", "Pham");
            var p2 = new Person ("Jonathan", "Murk");
            People.Add(p1);
            People.Add(p2);
            Actions.Add(new Talk(p1, "hello world!"));
            Actions.Add(new Travel(p2, "Angkovak", DateTime.Now));
        }
        public ActionResult<IEnumerable<Models.Action>> Get()
        {
            return Ok(Actions);
        }
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Models.Action> Get(int id)
        {
            if (id < 0)
            {
                return NotFound($"cannot find action with id {id}");
            }
            Models.Action? action = Actions?[id];
            action.Execute();
            return Ok(action);
        }
    }
}