using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using FluentAssertions;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Olo_APITestFramework
{
    [TestClass]
    public class JSONPlaceHolder_GETPostsTests
    {
        [TestMethod]
        public void GetAllPosts_ShouldReturn200()
        {
            RestClient client = new RestClient("https://jsonplaceholder.typicode.com/");
            RestRequest request = new RestRequest("posts/1");
            var response = client.Get(request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK, "because the Get call was successful");
     

        }
    }
}
