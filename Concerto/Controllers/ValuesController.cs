using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Concerto.Helper.APIAttribute;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Repository.Repositories;

namespace Concerto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequireApplicationKeyHeader]
    public class ValuesController : ControllerBase
    {
        private readonly IRoleRepository roleRepository;

        public ValuesController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("roles")]
        public ActionResult<IEnumerable<string>> GetRoles()
        {
            List<RoleDTO> roles = roleRepository.FindAll().ToList();
            return roles.Select(x => x.Name).ToList();
        }
    }
}
