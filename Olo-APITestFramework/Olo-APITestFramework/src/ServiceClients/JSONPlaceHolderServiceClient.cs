﻿using Newtonsoft.Json.Linq;
using Olo_APITestFramework.src.Helpers;
using Olo_APITestFramework.src.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Olo_APITestFramework.src.ServiceClients
{
    public class JSONPlaceHolderServiceClient
    {
        private RestClient _restClient { get; }
        private const string getAllPostsRoute = "posts";
        private const string getOnePostRoute = "posts/{0}";
        private const string postRoute = "posts";

        public JSONPlaceHolderServiceClient()
        {
            _restClient = AssemblyHelper.AUTRestClients["JSONPlaceHolder"];

        }

        public JSONPlaceHolderServiceClient(RestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<JSONPlaceHolderGetAllResponse> GetAllPosts()
        {
            RestRequest request = new RestRequest(getAllPostsRoute);
            Console.WriteLine(string.Format("Calling JsonPlaceHolder GetAllPosts at: {0}/{1} ", _restClient.BaseUrl, request.Resource));
            var response = await _restClient.ExecuteGetAsync<List<JSONPlaceHolderGetObject>>(request);

            return new JSONPlaceHolderGetAllResponse
            {
                statusCode = response.StatusCode,
                postObjectList = response.Data
            };
        }

        public async Task<JSONPlaceHolderGetOneResponse> GetOnePost(string postId)
        {
            RestRequest request = new RestRequest(string.Format(getOnePostRoute, postId));
            Console.WriteLine(
                string.Format("Calling JsonPlaceHolder GetOnePost with id {0} at: {1}{2} ", postId, _restClient.BaseUrl, request.Resource));
            var response = await _restClient.ExecuteGetAsync<JSONPlaceHolderGetObject>(request);

            return new JSONPlaceHolderGetOneResponse
            {
                statusCode = response.StatusCode,
                postObject = response.Data
            };
        }

        public async Task<JSONPlaceHolderPostOneResponse> PostNewPost(JSONPlaceHolderPostObject postObj)
        {
            RestRequest request = new RestRequest(postRoute);
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(postObj);
            //request.AddParameter("application/json", postObj, ParameterType.RequestBody);
            Console.WriteLine(
                string.Format("Calling JsonPlaceHolder Post at {0}{1} with body\n: {2} ",
                _restClient.BaseUrl, request.Resource, postObj.ToString()));
            var response = await _restClient.ExecutePostAsync<JSONPlaceHolderPostObject>(request);

            return new JSONPlaceHolderPostOneResponse
            {
                statusCode = response.StatusCode,
                postObject = response.Data
            };
        }

    }
}
