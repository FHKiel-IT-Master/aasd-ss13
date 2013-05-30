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
        public static void startBingSearch(string aQueryString, out SearchSystem.Result[] aResults)
        {
            var aBingContainer = new Bing.BingSearchContainer(new Uri(rootUri));    //create container which handles the connection to Bing
            aBingContainer.Credentials = new NetworkCredential(accountKey, accountKey);

            //Build the query and execute it/send it to Bing
            var aQuery = aBingContainer.Web(aQueryString, null, null, null, null, null, null, null);    //Query without any options, perhaps make them modifiable if useful
            var aQueryResults = aQuery.Execute();    //synchronous call to Bing

            //first get the number of results, than create the array, so there is no resizing necessary
            //int aNumberOfResults = 0;
            //foreach (var i in aQueryResults)
            //{
            //    aNumberOfResults++;
            //}
            aResults = new SearchSystem.Result[1];
            // now store all the values in the array
            int count = 0;
            foreach (var aResult in aQueryResults)
            {
                if (count != 0)
                    Array.Resize(ref aResults, aResults.Length + 1);
                
                aResults[count] = new SearchSystem.Result();
                aResults[count].mGuid = aResult.ID;
                aResults[count].mTitle = aResult.Title;
                aResults[count].mDescription = aResult.Description;
                aResults[count].mUrl = aResult.Url;
                aResults[count].mDisplayUrl = aResult.DisplayUrl;
            }

        
        }

        private static string rootUri = "https://api.datamarket.azure.com/Bing/Search";
        private static string accountKey = "mukZE9oHLj75rEkpKsRDXI6Aoa6DbzwoDyU9sRK0ahQ=";

    }
}
