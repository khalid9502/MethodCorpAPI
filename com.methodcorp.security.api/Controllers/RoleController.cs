using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace com.methodcorp.security.api.Controllers
{
    [RoutePrefix("security/Role")]
    public class RoleController : ApiController
    {
        SecurityStorage Storage = new SecurityStorage();

        [Route("{domainName}/{roleId}", Name = "GetRole")]

        public IHttpActionResult get(string domainName, long roleId)
        {
            RoleModel role = Storage.getRole(domainName, roleId);
            if (role != null)
            {
                return Ok(role);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{domainName}/{roleName}")]
        public IHttpActionResult DeleteRole(string domainName, string roleName)
        {
            long output = Storage.deleteRole(domainName, roleName);
            StatusCodeResult result = new StatusCodeResult(HttpStatusCode.NoContent, this);
            return result;
        }//DeleteRole

        [HttpPut]
        [Route("{roleId}")]
        public IHttpActionResult UpdateRole(long roleId, UpdateRoleModel role)
        {
            if (roleId == 0 || role.roleName.Equals(null) || role.roleName == string.Empty)
            {
                return BadRequest("enter a value for Role name");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            long output = Storage.updateRole(roleId, role.roleName, role.desc, role.userNames);
            return new StatusCodeResult(HttpStatusCode.NoContent, this);

        }//UpdateRole
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateRole([FromBody] CreateRoleModel role)
        {
            if (role.roleName.Equals(null) || role.roleName == string.Empty)
            {
                return BadRequest("enter a value for Role name");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            long roleId = Storage.createRole(role.domainName, role.roleName, role.userNames);
            RoleModel rol = Storage.getRole(role.domainName, roleId);
            return CreatedAtRoute("GetRole", new {domainName = role.domainName, roleId = roleId }, rol);
        }//CreateRole



    }//RoleController
}//com.methodcorp.security.api.Controllers
