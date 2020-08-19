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
    public class JSONPlaceHolder_POSTPostsTests
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
        public async Task PostBasicPost_ShouldReturn201_ShouldReturnPostedObject()
        {
            //Arrange
            JSONPlaceHolderPostObject postObj = new JSONPlaceHolderPostObject
            {
                body = "body",
                title = "this is our title",
                nestedEl = new NestedPostElement
                {
                    custom1 = "more custom fields",
                    custom2 = "even more custom fields"
                },
                userId = Guid.NewGuid()
            };

            //Act
            var response = await _jsonPlaceHolderServiceClient.PostNewPost(postObj);
            
            //Assert
            response.statusCode.Should().Be(System.Net.HttpStatusCode.Created, "because the Post was successful and returned 201");
            response.postObject.id.Should().Be(101, "because all new posts get a root level id of 101");
            //Could do more assertions here on response body values

        }

        [TestMethod]
        [TestCategory(Constants.TestCategories.JSONPlaceHolder_POSTEndpoints)]
        [TestCategory(Constants.TestCategories.Full)]
        public async Task PostWithEmptyBody_ShouldReturn201_ShouldReturnId101()
        {
            //Arrange
                // N/A

            //Act
            var response = await _jsonPlaceHolderServiceClient.PostNewPost();

            //Assert
            response.statusCode.Should().Be(System.Net.HttpStatusCode.Created, "because the Post was successful and returned 201");
            response.postObject.id.Should().Be(101, "because all new posts get a root level id of 101");
            

        }
    }
}
