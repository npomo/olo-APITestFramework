using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using FluentAssertions;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Olo_APITestFramework.src.Models;
using Olo_APITestFramework.src.Helpers;
using Olo_APITestFramework.src.ServiceClients;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Web.Configuration;

//testing rebase
namespace Olo_APITestFramework
{
    [TestClass]
    public class JSONPlaceHolder_DELETEPostsTests
    {
        private static JSONPlaceHolderServiceClient _jsonPlaceHolderServiceClient;

        [ClassInitialize]
        public static void FixtureSetup(TestContext context)
        {
            _jsonPlaceHolderServiceClient = new JSONPlaceHolderServiceClient();
        }

        [TestMethod]
        [TestCategory(Constants.TestCategories.JSONPlaceHolder_DELETEEndpoints)]
        [TestCategory(Constants.TestCategories.Full)]
        [TestCategory(Constants.TestCategories.Smoke)]
        public async Task DeleteExistingPost_ShouldReturn200()
        {
            //Arrange
            string postId = "99";

            //Act
            var response = await _jsonPlaceHolderServiceClient.DeletePost(postId);
            
            //Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK, "because the Delete was successful on an existing object and returned 200");
            
        }

        [TestMethod]
        [TestCategory(Constants.TestCategories.JSONPlaceHolder_DELETEEndpoints)]
        [TestCategory(Constants.TestCategories.Full)]
        public async Task DeleteNonExistingPost_ShouldReturn200()
        {
            //Arrange
            string postId = "101";

            //Act
            var response = await _jsonPlaceHolderServiceClient.DeletePost(postId);

            //Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK, "because the Delete returns a 200 on an element that doesnt already exist");
            //NOTE: I'm making an assumption on acceptance criteria for this assertion.  It's would also be acceptable for this delete to instead throw a NOTFOUND.
            
 
        }
    }
}
