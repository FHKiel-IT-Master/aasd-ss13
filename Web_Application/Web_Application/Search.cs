using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Application
{
    public class Search
    {
        private string a;

        //TODO: structure to store the results, should be replaced by the result class later

        public Search(string t)
        {
            a = t;
        }

        public string GetResults()
        {


            RequestHandler.Result[] aResults;

            BingSearchConnector.BingSearch.startBingSearch(a, out aResults);

            if (aResults[0] != null)  //if the first cell of the array is null, there were no results from Bing!
                return "String = " + a + "<br />" + aResults[0].mTitle + "<br />" + aResults[0].mDescription;
            else
                return "String = " + a + "<br />" + "Sorry, no results!";
        }
    }
}