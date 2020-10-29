using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olo_APITestFramework.src.Helpers
{
    [TestClass]
    //Class that initializes baseURLs and the RestSharp client that will be used by all tests
	public static class AssemblyHelper
    {
        public static Dictionary<string, RestClient> AUTRestClients { get; private set; }
		private static string _appUnderTestURLs = "AppUnderTestURL.";

		//Initialize will be called ahead of any test classes that execute since it's decorated with AssemblyInitialize
		//Initialize():
		//  - reads in all URLs from App.Config 
		//  - creates a dictionary of RestSharp clients that will be used by all tests in this project.  
		//      **Each dictionary entry is one client for each base URL defined in app.config
		//This is a comment with new changes
		[AssemblyInitialize]
		public static void Initialize(TestContext context)
        {
			AUTRestClients = CreateRestSharpClientsForUrls(_appUnderTestURLs);
			Console.WriteLine("Initializing RestClients");
			foreach (var client in AUTRestClients){
				Console.WriteLine(string.Format("RestClient create with BaseURL: {0}, Key: {1} ", client.Value.BaseUrl, client.Key));
			}
			
        }


		//CreateRestSharpClientsForUrls
		/**
		 * Params: urlType --> the prefix of the url key to search for in App.Config
		 * Returns: A <string, RestSharp> dictionary.  Each entry contains a unique key and RestSharp client for the urls defined in App.config
		**/
		private static Dictionary<string, RestClient> CreateRestSharpClientsForUrls(string urlType)
		{
			Dictionary<string, RestClient> clients = new Dictionary<string, RestClient>();
			var serviceKeys = ConfigurationManager.AppSettings.AllKeys.Where(k => k.StartsWith(urlType));
			if (serviceKeys.Any())
			{
				foreach (var key in serviceKeys)
				{
					var url = ConfigurationManager.AppSettings[key];
					var urlKey = key.Replace(urlType, string.Empty);
					if (!clients.ContainsKey(urlKey))
					{
						clients.Add(urlKey, new RestClient(url));

					}
				}	
			}

			return clients;
		}
	}
}
