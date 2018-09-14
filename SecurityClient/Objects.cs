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
    public static class Objects
    {
        public static async Task<Uri> CreateAsync(string domainName, long ownerId, List<objectSecurity> roles, List<objectSecurity> groups)
        {
            CreateObjectModel fromBodyObject = new CreateObjectModel();
            fromBodyObject.domainName = domainName;
            fromBodyObject.ownerId = ownerId;
            fromBodyObject.roles = roles;
            fromBodyObject.groups = groups;
            HttpResponseMessage response = await MyClient.client.PostAsJsonAsync("security/object", fromBodyObject);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
        public static async Task<ObjectModel> GetAsync(long objectId)
        {
            ObjectModel obj = null;
            HttpResponseMessage response = await MyClient.client.GetAsync(string.Format("security/object/{0}", objectId));
            if (response.IsSuccessStatusCode)
            {
                obj = await response.Content.ReadAsAsync<ObjectModel>();
            }
            return obj;
        }
        public static async Task<long> UpdateAsync(long objectId, long ownerId, List<objectSecurity> roles, List<objectSecurity> groups)
        {
            UpdateObjectModel fromBodyGroup = new UpdateObjectModel();
            fromBodyGroup.objectId = objectId;
            fromBodyGroup.ownerId = ownerId;
            fromBodyGroup.roles = roles;
            fromBodyGroup.groups = groups;
            long output = -1;
            HttpResponseMessage response = await MyClient.client.PostAsJsonAsync(string.Format("security/object/{0}", objectId), fromBodyGroup);
            if (response.IsSuccessStatusCode)
            {
                output = await response.Content.ReadAsAsync<long>();
            }
            return output;
        }
        public static async Task<HttpStatusCode> DeleteAsync(long objectId)
        {
            HttpResponseMessage response = await MyClient.client.DeleteAsync(string.Format("security/object/{0}", objectId));
            return response.StatusCode;

        }
    }
}
