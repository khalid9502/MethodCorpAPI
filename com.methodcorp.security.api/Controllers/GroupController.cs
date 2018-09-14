using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace com.methodcorp.security.api.Controllers
{
    [RoutePrefix("security/Group")]
    public class GroupController : ApiController
    {
        SecurityStorage Storage = new SecurityStorage();

        [Route("{domainName}/{groupId}",Name = "GetGroup")]

        public IHttpActionResult get(string domainName,long groupId)
        {
            GroupModel group = Storage.getGroup(domainName, groupId);
            if(group != null)
            {
                return Ok(group);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{domainName}/{groupName}")]
        public IHttpActionResult DeleteGroup(string domainName, string groupName)
        {
            long output = Storage.deleteGroup(domainName, groupName);
            StatusCodeResult result = new StatusCodeResult(HttpStatusCode.NoContent, this);
            return result;
        }//DeleteGroup

        [HttpPut]
        [Route("{groupId}")]
        public IHttpActionResult UpdateDomain(long groupId, UpdateGroupModel group)
        {
            if (groupId == 0 || group.groupName.Equals(null) || group.groupName == string.Empty)
            {
                return BadRequest("enter a value for group name");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            long output = Storage.updateGroup(groupId, group.groupName, group.desc, group.userNames);
            return new StatusCodeResult(HttpStatusCode.NoContent, this);

        }//UpdateDomain

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateDomain([FromBody] CreateGroupModel group)
        {
            if (group.groupName.Equals(null) || group.groupName == string.Empty)
            {
                return BadRequest("enter a value for group name");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            long groupId = Storage.createGroup(group.domainName,group.groupName,group.userNames);
            GroupModel gp = Storage.getGroup(group.domainName, groupId);
            return CreatedAtRoute("GetGroup", new { domainName = group.domainName, groupId = groupId }, group);
        }//CreateDomain
    }//GroupController
}//com.methodcorp.security.api.Controllers
