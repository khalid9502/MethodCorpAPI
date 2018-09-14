using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace com.methodcorp.security.api.Controllers
{
    [RoutePrefix("security/Policy")]
    public class PolicyController : ApiController
    {
        SecurityStorage Storage = new SecurityStorage();

        [Route("{policyId}", Name = "GetPolicy")]

        public IHttpActionResult GetPolicy(long policyId)
        {
            PolicyModel policy = Storage.getPolicy(policyId);
            if (policy != null)
            {
                return Ok(policy);
            }
            else
            {
                return NotFound();
            }
        }//GetPolicy
        
        [HttpDelete]
        [Route("{domainName}/{policyName}")]
        public IHttpActionResult DeletePolicy(string domainName, string policyName)
        {
            long output = Storage.deletePolicy(domainName, policyName);
            StatusCodeResult result = new StatusCodeResult(HttpStatusCode.NoContent, this);
            return result;
        }//DeletePolicy

        [HttpPut]
        [Route("domainName")]
        public IHttpActionResult UpdatePolicy(string domainName, UpdatePolicyModel policy)
        {
            if (policy.policyId == 0)
            {
                return BadRequest("enter a value for Policy ID");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            long output = Storage.updatePolicy(domainName, policy.parentPolicyName, policy.policyId, policy.groups, policy.roles);
            return new StatusCodeResult(HttpStatusCode.NoContent, this);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreatePolicy([FromBody] CreatePolicyModel policy)
        {
            if (policy.domainName.Equals(null) || policy.domainName == string.Empty)
            {
                return BadRequest("enter a value for domain name");
            }
            if (policy.policyName.Equals(null) || policy.policyName == string.Empty)
            {
                return BadRequest("enter a value for domain name");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            long policyId = Storage.createPolicy(policy.domainName, policy.parentPolicyName, policy.policyName, policy.groups, policy.roles);
            ObjectModel pol = Storage.getObject(policyId);
            return CreatedAtRoute("GetPolicy", new { policyId = policyId }, pol);
        }//CreatePolicy
    }//PolicyController
}//com.methodcorp.security.api.Controllers
