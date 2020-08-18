using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olo_APITestFramework.src.Models
{
    public class JSONPlaceHolderGetObject
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

    }

    public class JSONPlaceHolderGetAllResponse
    {
        public System.Net.HttpStatusCode statusCode { get; set; }
        public List<JSONPlaceHolderGetObject> postObjectList{ get; set ;}
    }

    public class JSONPlaceHolderGetOneResponse
    {
        public System.Net.HttpStatusCode statusCode { get; set; }
        public JSONPlaceHolderGetObject postObject { get; set; }
    }
}
