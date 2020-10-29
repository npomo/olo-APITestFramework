using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//new branch commit 4
//master commit 9
namespace Olo_APITestFramework.src.Models
{
    public class JSONPlaceHolderPostObject
    {
        public Guid userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public NestedPostElement nestedEl { get; set; }

    }

    public class NestedPostElement
    {
        public string custom1 { get; set; }
        public string custom2 { get; set; }
    }

    public class JSONPlaceHolderPostOneResponse
    {
        public System.Net.HttpStatusCode statusCode { get; set; }
        public JSONPlaceHolderPostObject postObject { get; set; }
    }
//commit 8
//commit 11
//commit 12
}
