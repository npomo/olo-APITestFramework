using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using FluentAssertions;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Olo_APITestFramework.src.Models;
using System.Collections.Generic;

namespace Olo_APITestFramework
{
    [TestClass]
    public class JSONPlaceHolder_GETPostsTests
    {
              
        [TestMethod]
        public void GetAllPosts_ShouldReturn200_ShouldReturn100PostObjects()
        {
            RestClient client = new RestClient("https://jsonplaceholder.typicode.com/");
            RestRequest request = new RestRequest("posts");
            var response = client.Get(request);

            List<JSONPlaceHolderPostResponse> postsList = JsonConvert.DeserializeObject<List<JSONPlaceHolderPostResponse>>(response.Content);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK, "because the Get call was successful");
            postsList.Count.Should().Be(100, "because JSONPlaceHolder get all always returns 100 elements");
            //Could do more assertions here based on AC of specific GetAll call API
     
        }

        [TestMethod]
        public void GetOnePost_ShouldReturn200_ShouldReturnDesiredPostObject()
        {
            RestClient client = new RestClient("https://jsonplaceholder.typicode.com/");
            RestRequest request = new RestRequest("posts/72");
            var response = client.Get(request);

            JSONPlaceHolderPostResponse targetPost = JsonConvert.DeserializeObject<JSONPlaceHolderPostResponse>(response.Content);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK, "because the Get call was successful");
            targetPost.userId.Should().Be(8, "because we expect post id 72 has a userID value of 8");
            targetPost.id.Should().Be(72, "because we expect post id 72 has a id value of 72");
            targetPost.title.Should().Be("sint hic doloribus consequatur eos non id", "because we expect this title string value for post id 72");
            targetPost.body.Should().Be("quam occaecati qui deleniti consectetur\nconsequatur aut facere quas exercitationem aliquam hic voluptas\nneque id sunt ut aut accusamus\nsunt consectetur expedita inventore velit", "because we expect this title string value for post id 72");
            //Could do more assertions here based on AC of specific Get one call 

        }
    }
}
