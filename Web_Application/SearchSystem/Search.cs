using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchSystem
{
    public class Search
    {
        private string context;
        private string input;
        private List<SearchSystem.Result> aResults;

        //TODO: structure to store the results, should be replaced by the result class later

        public Search(string a, string b)
        {
            input = a;
            context = b;

            //Likely here the contexts should also be created
        }

        public string StringBuilder()
        {
            //Here the search string is properly built
            return "test";
        }

        public void WebSearchProcess()
        {
            SearchSystem.BingSearch.startBingSearch(input, out aResults);
        }

        public string GetResults()
        {
            string result="";

            if (aResults[0] != null)  //if the first cell of the array is null, there were no results from Bing!
            {
                foreach (SearchSystem.Result r in aResults)
                {
                    result += "<p><a href='" + r.mUrl + "' target='_blank'>" + r.mTitle + "</a><p>" + r.mDescription + "<br /><br />";
                }
            }
            else
                result = "<h2>No results<h2>";

            return result;

        }

    }
}