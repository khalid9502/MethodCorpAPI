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
    public static class Roles
    {
        public static async Task<Uri> CreateAsync(string domainName, string roleName, List<string> userNames)
        {
            CreateRoleModel fromBodyRole = new CreateRoleModel();
            fromBodyRole.domainName = domainName;
            fromBodyRole.roleName = roleName;
            fromBodyRole.userNames = userNames;
            HttpResponseMessage response = await MyClient.client.PostAsJsonAsync("security/role", fromBodyRole);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
        public static async Task<PolicyModel> GetAsync(string domainName, long roleId)
        {
            PolicyModel role = null;
            HttpResponseMessage response = await MyClient.client.GetAsync(string.Format("security/role/{0}/{1}", domainName, roleId));
            if (response.IsSuccessStatusCode)
            {
                role = await response.Content.ReadAsAsync<PolicyModel>();
            }
            return role;
        }
        public static async Task<long> UpdateAsync(long roleId, string roleName, string desc, List<string> userNames)
        {
            UpdateRoleModel fromBodyRole = new UpdateRoleModel();
            fromBodyRole.roleId = roleId;
            fromBodyRole.roleName = roleName;
            fromBodyRole.desc = desc;
            fromBodyRole.userNames = userNames;
            long output = -1;
            HttpResponseMessage response = await MyClient.client.PostAsJsonAsync(string.Format("security/role/{0}", roleId), fromBodyRole);
            if (response.IsSuccessStatusCode)
            {
                output = await response.Content.ReadAsAsync<long>();
            }
            return output;
        }
        public static async Task<HttpStatusCode> DeleteAsync(string domainName, string roleName)
        {
            HttpResponseMessage response = await MyClient.client.DeleteAsync(string.Format("security/role/{0}/{1}", domainName, roleName));
            return response.StatusCode;

        }

    }
}
