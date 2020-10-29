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
        [TestCategory(Constants.TestCategories.Smoke)]
        public async Task GetAllPosts_ShouldReturn200_ShouldReturn100PostObjects()
        {
            //Arrange 
              // N/A

            //Act
            JSONPlaceHolderGetAllResponse response = await _jsonPlaceHolderServiceClient.GetAllPosts();

            //Assert
            response.statusCode.Should().Be(System.Net.HttpStatusCode.OK, "because the Get call returned 200");
            response.postObjectList.Count.Should().Be(100, "because JSONPlaceHolder get all always returns 100 response objects");
            
            //Could do more assertions here based on AC of specific GetAll call API
     
        }

        [TestMethod]
        [TestCategory(Constants.TestCategories.JSONPlaceHolder_GETEndpoints)]
        [TestCategory(Constants.TestCategories.Full)]
        [TestCategory(Constants.TestCategories.Smoke)]
        public async Task GetOnePost_ShouldReturn200_ShouldReturnDesiredPostObject()
        {
            //Arrange
              // N/A
            
            //Act
            JSONPlaceHolderGetOneResponse response = await _jsonPlaceHolderServiceClient.GetOnePost("72");

            //Assert
            response.statusCode.Should().Be(System.Net.HttpStatusCode.OK, "because the Get call returned 200");
            response.postObject.userId.Should().Be(8, "because we expect post id 72 has a userID value of 8");
            response.postObject.id.Should().Be(72, "because we expect post id 72 has a id value of 72");
            response.postObject.title.Should().Be("sint hic doloribus consequatur eos non id", "because we expect this title string value for post id 72");
            response.postObject.body.Should().Be("quam occaecati qui deleniti consectetur\nconsequatur aut facere quas exercitationem aliquam hic voluptas\nneque id sunt ut aut accusamus\nsunt consectetur expedita inventore velit", "because we expect this title string value for post id 72");
            //Could do more assertions here based on AC of specific Get one call 

        }

        [TestMethod]
        [TestCategory(Constants.TestCategories.JSONPlaceHolder_GETEndpoints)]
        [TestCategory(Constants.TestCategories.Full)]
        [DataRow("101")]
        [DataRow("text")]
        public async Task GetOnePost_InvalidPostID_ShouldReturn404(string postId) 
        {
            //Arrange
            // N/A

            //Act
            JSONPlaceHolderGetOneResponse response = await _jsonPlaceHolderServiceClient.GetOnePost(postId);

            //Assert
            response.statusCode.Should().Be(System.Net.HttpStatusCode.NotFound, 
                string.Format("because there should never be a post with ID {0}", postId));
            response.postObject.userId.Should().Be(0, "because we did not find a valid Post");
            response.postObject.id.Should().Be(0, "because we did not find a valid Post");
            response.postObject.title.Should().BeNull("there is no title to return for an invalid PostID");
            response.postObject.body.Should().BeNull("there is no body to return for an invalid PostID");


        }

        //newbranch commit 5

    }
}
