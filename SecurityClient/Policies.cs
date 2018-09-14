using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using com.methodcorp.security;

namespace SecurityClient
{
    public static class Policies
    {

        public static async Task<Uri> CreateAsync(string domainName, string parentPolicyName, string policyName, List<policySecurity> groups, List<policySecurity> roles)
        {
            CreatePolicyModel fromBodyPolicy = new CreatePolicyModel();
            fromBodyPolicy.domainName = domainName;
            fromBodyPolicy.parentPolicyName = parentPolicyName;
            fromBodyPolicy.policyName = policyName;
            fromBodyPolicy.groups = groups;
            fromBodyPolicy.roles = roles;
            HttpResponseMessage response = await MyClient.client.PostAsJsonAsync("security/policy", fromBodyPolicy);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
        public static async Task<PolicyModel> GetAsync(long policyId)
        {
            PolicyModel policy = null;
            HttpResponseMessage response = await MyClient.client.GetAsync(string.Format("security/policy/{0}", policyId));
            if (response.IsSuccessStatusCode)
            {
                policy = await response.Content.ReadAsAsync<PolicyModel>();
            }
            return policy;
        }
        public static async Task<long> UpdateAsync(string domainName, string parentPolicyName, long policyId, List<policySecurity> groups, List<policySecurity> roles)
        {
            UpdatePolicyModel fromBodyPolicy = new UpdatePolicyModel();
            fromBodyPolicy.domainName = domainName;
            fromBodyPolicy.policyId = policyId;
            fromBodyPolicy.groups = groups;
            fromBodyPolicy.roles = roles;
            long output = -1;
            HttpResponseMessage response = await MyClient.client.PostAsJsonAsync(string.Format("security/policy/{0}", domainName), fromBodyPolicy);
            if (response.IsSuccessStatusCode)
            {
                output = await response.Content.ReadAsAsync<long>();
            }
            return output;
        }
        public static async Task<HttpStatusCode> DeleteAsync(string domainName, string policyName)
        {
            HttpResponseMessage response = await MyClient.client.DeleteAsync(string.Format("security/policy/{0}/{1}", domainName, policyName));
            return response.StatusCode;

        }

    }
}
