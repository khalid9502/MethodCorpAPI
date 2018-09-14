using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace com.methodcorp.security.api.Controllers
{
    [RoutePrefix("security/Object")]
    public class ObjectController : ApiController
    {
        SecurityStorage Storage = new SecurityStorage();

        [Route("{objectId}", Name = "GetObject")]
        public IHttpActionResult get(long objectId)
        {
            ObjectModel Myobject = Storage.getObject(objectId);
            if (Myobject != null)
            {
                return Ok(Myobject);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{objectId}")]
        public IHttpActionResult DeleteObject(long objectId)
        {
            long output = Storage.deleteObject(objectId);
            StatusCodeResult result = new StatusCodeResult(HttpStatusCode.NoContent, this);
            return result;
        }//DeleteObject

        [HttpPut]
        [Route("{objectId}")]
        public IHttpActionResult UpdateDomain(long objectId, UpdateObjectModel objectValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            long output = Storage.updateObject(objectId, objectValue.ownerId, objectValue.roles, objectValue.groups);
            return new StatusCodeResult(HttpStatusCode.NoContent, this);
        }//UpdateDomain

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateObject([FromBody] CreateObjectModel obj)
        {
            if (obj.domainName.Equals(null) || obj.domainName == string.Empty)
            {
                return BadRequest("enter a value for domain name");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            long objectId = Storage.createObject(obj.domainName, obj.ownerId, obj.roles, obj.groups);
            ObjectModel ob = Storage.getObject(objectId);
            return CreatedAtRoute("GetObject", new {objectId = objectId }, ob);
        }//CreateObject
    }//ObjectController
}//com.methodcorp.security.api.Controllers
