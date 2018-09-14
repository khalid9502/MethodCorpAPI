using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace com.methodcorp.security.api.Controllers
{
    [RoutePrefix("security/User")]
    public class UserController : ApiController
    {
        SecurityStorage Storage = new SecurityStorage();

        [Route("{domainName}/{userId}", Name = "GetUser")]

        public IHttpActionResult get(string domainName, long userId)
        {
            UserModel user = Storage.getUser(domainName, userId);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{domainName}/{userName}")]
        public IHttpActionResult DeleteUser(string domainName, string userName)
        {
            long output = Storage.deleteUser(domainName, userName);
            StatusCodeResult result = new StatusCodeResult(HttpStatusCode.NoContent, this);
            return result;
        }//DeleteUser

        [HttpPut]
        [Route("{userId}")]
        public IHttpActionResult UpdateUser(long userId, UpdateUserModel user)
        {
            if (userId == 0 || user.userName.Equals(null) || user.userName == string.Empty)
            {
                return BadRequest("enter a value for domain name");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            long output = Storage.updateUser(userId, user.userName, user.roleNames, user.groupNames);
            return new StatusCodeResult(HttpStatusCode.NoContent, this);

        }//UpdateUser
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateUser([FromBody] CreateUserModel user)
        {
            if (user.domainName.Equals(null) || user.domainName == string.Empty)
            {
                return BadRequest("enter a value for domain name");
            }
            if (user.userName.Equals(null) || user.userName == string.Empty)
            {
                return BadRequest("enter a value for user name");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            long userId = Storage.createUser(user.domainName, user.userName, user.roleNames, user.groupNames);
            UserModel usr = Storage.getUser(user.domainName, userId);
            return CreatedAtRoute("GetUser", new { domainName = user.domainName, userId = userId }, usr);
        }//CreateUser



    }//UserController
}//com.methodcorp.security.api.Controllers
