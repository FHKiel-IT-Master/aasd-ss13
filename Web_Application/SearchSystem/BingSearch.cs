using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace SearchSystem
{
    public class BingSearch
    {
        public static void startBingSearch(string aQueryString, List<SearchSystem.Result> aResults)
        {
            var aBingContainer = new Bing.BingSearchContainer(new Uri(rootUri));    //create container which handles the connection to Bing
            aBingContainer.Credentials = new NetworkCredential(accountKey, accountKey);

            //Build the query and execute it/send it to Bing
            var aQuery = aBingContainer.Web(aQueryString, null, null, null, null, null, null, null);    //Query without any options, perhaps make them modifiable if useful
            var aQueryResults = aQuery.Execute();    //synchronous call to Bing

            // now store all the values in the array

            foreach (var aResult in aQueryResults)
            {
                aResults.Add(new SearchSystem.Result()
                {
                    id = aResult.ID,
                    title = aResult.Title,
                    description = aResult.Description,
                    displayURL = aResult.Url,
                    url = aResult.DisplayUrl
                });
            }

        
        }

        private static string rootUri = "https://api.datamarket.azure.com/Bing/Search";
        private static string accountKey = "mukZE9oHLj75rEkpKsRDXI6Aoa6DbzwoDyU9sRK0ahQ=";

    }
}
