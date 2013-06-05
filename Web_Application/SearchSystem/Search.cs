using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace SearchSystem
{
    public class Search
    {
        private string sContext;
        private string input;
        public List<Result> aResults { get; protected set; }
        public List<Context> contexts { get; private set;}

        public Search(string a, string b)
        {
            input = a;
            sContext = b;

            aResults = new List<SearchSystem.Result>();
            contexts = new List<Context>();

            //Contexts should also be created for further use in the string builder and refinement.
            Regex rg = new Regex("%(.*?)%");
            Match tmp = rg.Match(sContext);
            while (tmp.Success)
            {
                //Here connects to database to get the other necessary values to the context class
                //If we are to use sub-contexts this part would need a re-coding.
                contexts.Add(new Context() { name = tmp.Groups[1].ToString()});
                tmp = tmp.NextMatch();
            }

        }

        public string StringBuilder()
        {
            //Here the search string is properly built
            string queryString = input;
            foreach (var element in contexts) 
            {
                queryString += " + " + element.name; //string at the end will be: "input + context1 + context2 ..." 
            }
            return queryString;
        }

        public void WebSearchProcess()
        {
            BingSearch.startBingSearch(StringBuilder(), aResults);
        }

        public string GetResults()
        {
            string result="";

            if (aResults[0] != null)  //if the first cell of the array is null, there were no results from Bing!
            {
                foreach (Result r in aResults)
                {
                    result += "<p><a href='" + r.url + "' target='_blank'>" + r.title + "</a><p>" + r.description + "<br /><br />";
                }
            }
            else
                result = "<h2>No results<h2>";

            return result;

        }

    }
}