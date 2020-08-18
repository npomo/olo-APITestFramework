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
              // N/A
            
            //Act
            dynamic response = await _jsonPlaceHolderServiceClient.PostNewPost(TestData.Post.BasicPost);

            //Assert
            response.statusCode.Should().Be(System.Net.HttpStatusCode.Created, "because the Post was successful and returned 201");
            //Could do more assertions here based on AC of specific Get one call 

        }

    }
}
