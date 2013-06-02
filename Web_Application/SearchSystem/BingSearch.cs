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
        public static void startBingSearch(string aQueryString, out List<SearchSystem.Result> aResults)
        {
            var aBingContainer = new Bing.BingSearchContainer(new Uri(rootUri));    //create container which handles the connection to Bing
            aBingContainer.Credentials = new NetworkCredential(accountKey, accountKey);

            //Build the query and execute it/send it to Bing
            var aQuery = aBingContainer.Web(aQueryString, null, null, null, null, null, null, null);    //Query without any options, perhaps make them modifiable if useful
            var aQueryResults = aQuery.Execute();    //synchronous call to Bing

            aResults = new List<SearchSystem.Result>();
            // now store all the values in the array

            foreach (var aResult in aQueryResults)
            {
                aResults.Add(new SearchSystem.Result()
                {
                    mGuid = aResult.ID,
                    mTitle = aResult.Title,
                    mDescription = aResult.Description,
                    mUrl = aResult.Url,
                    mDisplayUrl = aResult.DisplayUrl
                });
            }

        
        }

        private static string rootUri = "https://api.datamarket.azure.com/Bing/Search";
        private static string accountKey = "mukZE9oHLj75rEkpKsRDXI6Aoa6DbzwoDyU9sRK0ahQ=";

    }
}
