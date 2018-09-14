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
    public static class Domains
    {
        public static async Task<Uri> CreateAsync(string domainName)
        {
           HttpResponseMessage response = await MyClient.client.PostAsJsonAsync("security/domainName", domainName);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
        public static async Task<DomainModel> GetAsync(string domainName)
        {
            DomainModel domain = null;
            HttpResponseMessage response = await MyClient.client.GetAsync(string.Format("security/domain/{0}", domainName));
            if (response.IsSuccessStatusCode)
            {
                domain = await response.Content.ReadAsAsync<DomainModel>();
            }
            return domain;
        }
        public static async Task<long> UpdateAsync(long domainId, string domainName)
        {
            long output = -1;
            HttpResponseMessage response = await MyClient.client.PostAsJsonAsync(string.Format("security/domain/{0}", domainId), domainName);
            if (response.IsSuccessStatusCode)
            {
                output = await response.Content.ReadAsAsync<long>();
            }
            return output;
        }
        public static async Task<HttpStatusCode> DeleteAsync(string domainName)
        {
            HttpResponseMessage response = await MyClient.client.DeleteAsync(string.Format("security/domain/{0}", domainName));
            return response.StatusCode;

        }
    }
}
