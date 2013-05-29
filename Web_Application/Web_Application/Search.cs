using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Application
{
    public class Search
    {
        private string context;
        private string input;
        private RequestHandler.Result[] aResults;

        //TODO: structure to store the results, should be replaced by the result class later

        public Search(string a, string b)
        {
            context = b;
            input = a;
        }

        public string StringBuilder()
        {
            //Here the search string is properly built
            return "test";
        }

        public void WebSearchProcess()
        {
            BingSearchConnector.BingSearch.startBingSearch(input, out aResults);
        }

        public string GetResults()
        {
            if (aResults[0] != null)  //if the first cell of the array is null, there were no results from Bing!
                return "String = " + input + "<br />" + aResults[0].mTitle + "<br />" + aResults[0].mDescription;
            else
                return "String = " + input + "<br />" + "Sorry, no results!";
        }

    }
}