using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Data;
using com.methodcorp.security;

namespace SecurityClient
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }
        static async Task RunAsync()
        {
            MyClient.client.BaseAddress = new Uri("http://localhost:49530");
            MyClient.client.DefaultRequestHeaders.Accept.Clear();
            MyClient.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                DomainModel url = await Domains.GetAsync("domain2");
                Console.WriteLine("domain was created at {0}", url);

                DomainModel domain = await Domains.GetAsync("domain2");
                Console.WriteLine("created");

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();

            }
            Console.ReadLine();
        }
    }
}
