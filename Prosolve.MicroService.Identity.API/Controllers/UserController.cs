using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using Prosolve.MicroService.Identity.Entities.Users;

namespace Prosolve.MicroService.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public UserController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new[]
                   {
                       "value1",
                       "value2"
                   };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            var userBuilder = new UserBuilder().SetVersion(1);
            _identityService.CreateUsers(new IUserBuilder[]
                                         {
                                             userBuilder
                                         });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
