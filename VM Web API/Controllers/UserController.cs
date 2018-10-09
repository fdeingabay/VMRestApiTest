using Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VM_Web_API.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public IHttpActionResult Get(int id)
        {
            var user = this.userService.GetByID(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        [Route("api/users/")]
        public IHttpActionResult GetAll()
        {
            var users = this.userService.GetAll();

            if (users.Any())
            {
                return Ok(users);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("api/users/")]
        public IHttpActionResult Insert(Entities.User user)
        {
            if (ModelState.IsValid)
            {
                this.userService.Insert(user);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("api/users/")]
        public IHttpActionResult Update(Entities.User user)
        {
            try
            {
                this.userService.Update(user);
            }
            catch(InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpDelete]
        [Route("api/users/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                this.userService.Delete(id);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}
