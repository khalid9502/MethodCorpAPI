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
    public static class Groups
    {

        public static async Task<Uri> CreateAsync(string domainName, string groupName, List<string> userNames)
        {
            CreateGroupModel fromBodyGoup = new CreateGroupModel();
            fromBodyGoup.domainName = domainName;
            fromBodyGoup.groupName = groupName;
            fromBodyGoup.userNames = userNames;
            HttpResponseMessage response = await MyClient.client.PostAsJsonAsync("security/group", fromBodyGoup);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
        public static async Task<GroupModel> GetAsync(string domainName, long groupId)
        {
            GroupModel group = null;
            HttpResponseMessage response = await MyClient.client.GetAsync(string.Format("security/group/{0}/{1}", domainName,groupId));
            if (response.IsSuccessStatusCode)
            {
                group = await response.Content.ReadAsAsync<GroupModel>();
            }
            return group;
        }
        public static async Task<long> UpdateAsync(long groupId, string groupName, string desc, List<string> userNames)
        {
            UpdateGroupModel fromBodyGroup = new UpdateGroupModel();
            fromBodyGroup.groupId = groupId;
            fromBodyGroup.groupName = groupName;
            fromBodyGroup.desc = desc;
            fromBodyGroup.userNames = userNames;
            long output = -1;
            HttpResponseMessage response = await MyClient.client.PostAsJsonAsync(string.Format("security/group/{0}", groupId), fromBodyGroup);
            if (response.IsSuccessStatusCode)
            {
                output = await response.Content.ReadAsAsync<long>();
            }
            return output;
        }
        public static async Task<HttpStatusCode> DeleteAsync(string domainName, string groupName)
        {
            HttpResponseMessage response = await MyClient.client.DeleteAsync(string.Format("security/group/{0}/{1}", domainName,groupName));
            return response.StatusCode;

        }

    }
}
