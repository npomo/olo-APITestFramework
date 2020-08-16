using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olo_APITestFramework.src.Models
{
    public class JSONPlaceHolderPost
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

    }

    public class JSONPlaceHolderGetAllPostsResponse
    {
        public System.Net.HttpStatusCode statusCode { get; set; }
        public List<JSONPlaceHolderPost> postObjectList{ get; set ;}
    }

    public class JSONPlaceHolderGetOnePostResponse
    {
        public System.Net.HttpStatusCode statusCode { get; set; }
        public JSONPlaceHolderPost postObject { get; set; }
    }
}
