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
    public static class Users
    {
        

        public static async Task<Uri> CreateAsync(string domainName, string userName, List<string> roleNames, List<string> groupNames)
        {
            CreateUserModel fromBodyUser = new CreateUserModel();
            fromBodyUser.domainName = domainName;
            fromBodyUser.userName = userName;
            fromBodyUser.roleNames = roleNames;
            fromBodyUser.groupNames = groupNames;
            HttpResponseMessage response = await MyClient.client.PostAsJsonAsync("security/role", fromBodyUser);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
        public static async Task<UserModel> GetAsync(string domainName, long userId)
        {
            UserModel user = null;
            HttpResponseMessage response = await MyClient.client.GetAsync(string.Format("security/user/{0}/{1}", domainName, userId));
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<UserModel>();
            }
            return user;
        }
        public static async Task<long> UpdateAsync(long userId, string userName, List<string> roleNames, List<string> groupNames)
        {
            UpdateUserModel fromBodyUser = new UpdateUserModel();
            fromBodyUser.userId = userId;
            fromBodyUser.userName = userName;
            fromBodyUser.roleNames = roleNames;
            fromBodyUser.groupNames = groupNames;
            long output = -1;
            HttpResponseMessage response = await MyClient.client.PostAsJsonAsync(string.Format("security/user/{0}", userId), fromBodyUser);
            if (response.IsSuccessStatusCode)
            {
                output = await response.Content.ReadAsAsync<long>();
            }
            return output;
        }
        public static async Task<HttpStatusCode> DeleteAsync(string domainName, string userName)
        {
            HttpResponseMessage response = await MyClient.client.DeleteAsync(string.Format("security/user/{0}/{1}", domainName, userName));
            return response.StatusCode;

        }
    }
}
