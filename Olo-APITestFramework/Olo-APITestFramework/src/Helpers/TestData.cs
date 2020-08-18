using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Olo_APITestFramework.src.Helpers
{
    public static class TestData
    {
        public static class Post
        {
            public static JObject BasicPost = JObject.Parse(string.Format(@"
            {
                'title': 'Welcome to Olo',
                'body': 'We hope that you enjoy working here',
                'userId': {0}
            }
            ", Guid.NewGuid()));
                            
            public static JObject EmptyPost = new JObject{};

            public static JObject ElaboratePost = JObject.Parse(string.Format(@"
            [
                {
                    'title': 'ElaborateJson',
                    'body': 'This has more elements and nested objects',
                    'nestedElement':
                        {
                            'nest1': 'value1',
                            'nest2': 'value2'
                        },
                    'userId': '{0}'
                },
                {
                    'title': 'ElaborateJson2',
                    'body': 'BodyNumber2',
                    'nestedElement':
                        {
                            'nest1': 'value1SecondEl',
                            'nest2': 'value2SecondEl'
                        },
                    'userId': '{1}'
                }
            ]
            ", Guid.NewGuid(), Guid.NewGuid()));
        }

    }
}
