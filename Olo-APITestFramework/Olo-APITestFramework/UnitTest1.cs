using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Olo_APITestFramework
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            RestClient client = new RestClient("https://jsonplaceholder.typicode.com/");

            RestRequest request2 = new RestRequest("posts/1", Method.GET);
            var response2 = await client.ExecuteGetAsync(request2);
            
            RestRequest request = new RestRequest("posts/1", Method.GET);
            var response = await client.ExecuteGetAsync(request);

            await Console.Out.WriteLineAsync(response2.Content + " |||| " + response.Content);

        }
    }
}
