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

namespace Olo_APITestFramework
{
    [TestClass]
    public class JSONPlaceHolder_PUTPostsTests
    {
        private static JSONPlaceHolderServiceClient _jsonPlaceHolderServiceClient;

        [ClassInitialize]
        public static void FixtureSetup(TestContext context)
        {
            _jsonPlaceHolderServiceClient = new JSONPlaceHolderServiceClient();
        }

        [TestMethod]
        [TestCategory(Constants.TestCategories.JSONPlaceHolder_POSTEndpoints)]
        [TestCategory(Constants.TestCategories.Full)]
        [TestCategory(Constants.TestCategories.Smoke)]
        public async Task PutBasicPost_ShouldReturn200_ShouldReturnPutObject()
        {
            //Arrange
            JSONPlaceHolderPostObject postObj = new JSONPlaceHolderPostObject
            {
                body = "putBody",
                title = "the title",
                nestedEl = new NestedPostElement
                {
                    custom1 = "custom field value 1",
                    custom2 = "even more custom fields"
                },
                userId = Guid.NewGuid()
            };
            string postId = "50";

            //Act
            var response = await _jsonPlaceHolderServiceClient.PutExistingPost(postId, postObj);
            
            //Assert
            response.statusCode.Should().Be(System.Net.HttpStatusCode.OK, "because the Put was successful and returned 200");
            response.postObject.id.Should().Be(Int32.Parse(postId), string.Format("because we performed the PUT method on id {0}", postId));
            response.postObject.Should().BeOfType<JSONPlaceHolderPostObject>("because the Put call should have updated the body of id 50");
            //Could do more assertions here based on AC of specific Get one call 

        }

        [TestMethod]
        [TestCategory(Constants.TestCategories.JSONPlaceHolder_POSTEndpoints)]
        [TestCategory(Constants.TestCategories.Full)]
        [TestCategory(Constants.TestCategories.Smoke)]
        public async Task PutWithEmptyBody_ShouldReturn200_ShouldReturnId()
        {
            //Arrange
            string postId = "35";

            //Act
            var response = await _jsonPlaceHolderServiceClient.PutExistingPost(postId);

            //Assert
            response.statusCode.Should().Be(System.Net.HttpStatusCode.OK, "because the Put was successful and returned 200");
            response.postObject.id.Should().Be(Int32.Parse(postId), 
                string.Format("because we performed the PUT method on id {0} and thus that ID was returned", postId));
 
            //Could do more assertions here based on AC of specific Get one call 

        }
    }
}
