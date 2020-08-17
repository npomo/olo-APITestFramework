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
    public class JSONPlaceHolder_GETPostsTests
    {
        private static JSONPlaceHolderServiceClient _jsonPlaceHolderServiceClient;

        [ClassInitialize]
        public static void FixtureSetup(TestContext context)
        {
            _jsonPlaceHolderServiceClient = new JSONPlaceHolderServiceClient();
        }

        [TestMethod]
        [TestCategory(Constants.TestCategories.JSONPlaceHolder_GETEndpoints)]
        [TestCategory(Constants.TestCategories.Full)]
        public async Task GetAllPosts_ShouldReturn200_ShouldReturn100PostObjects()
        {
            //Arrange 
              // N/A

            //Act
            JSONPlaceHolderGetAllPostsResponse response = await _jsonPlaceHolderServiceClient.GetAllPosts();

            //Assert
            response.statusCode.Should().Be(System.Net.HttpStatusCode.OK, "because the Get call returned 200");
            response.postObjectList.Count.Should().Be(100, "because JSONPlaceHolder get all always returns 100 response objects");
            
            //Could do more assertions here based on AC of specific GetAll call API
     
        }

        [TestMethod]
        [TestCategory(Constants.TestCategories.JSONPlaceHolder_GETEndpoints)]
        [TestCategory(Constants.TestCategories.Full)]
        public async Task GetOnePost_ShouldReturn200_ShouldReturnDesiredPostObject()
        {
            //Arrange
              // N/A
            
            //Act
            JSONPlaceHolderGetOnePostResponse response = await _jsonPlaceHolderServiceClient.GetOnePost("72");

            //Assert
            response.statusCode.Should().Be(System.Net.HttpStatusCode.OK, "because the Get call returned 200");
            response.postObject.userId.Should().Be(8, "because we expect post id 72 has a userID value of 8");
            response.postObject.id.Should().Be(72, "because we expect post id 72 has a id value of 72");
            response.postObject.title.Should().Be("sint hic doloribus consequatur eos non id", "because we expect this title string value for post id 72");
            response.postObject.body.Should().Be("quam occaecati qui deleniti consectetur\nconsequatur aut facere quas exercitationem aliquam hic voluptas\nneque id sunt ut aut accusamus\nsunt consectetur expedita inventore velit", "because we expect this title string value for post id 72");
            //Could do more assertions here based on AC of specific Get one call 

        }
    }
}
