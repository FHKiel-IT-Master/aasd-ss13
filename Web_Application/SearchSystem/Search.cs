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
        private string Context;
        private string input;
        public List<Result> Results { get; protected set; }
        public List<Context> contexts { get; private set;}

        public Search(string a, string b)
        {
            input = a;
            Context = b;

            Results = new List<SearchSystem.Result>();
            contexts = new List<Context>();

            //Contexts should also be created for further use in the string builder and refinement.
            Regex rg = new Regex("%(.*?)%");
            Match tmp = rg.Match(Context);
            DataAccess.DBConnector.openConnection();

            while (tmp.Success)
            {
                SqlDataReader dbresult = DataAccess.DBConnector.executeQuery("SELECT VALUE FROM CONT_TAG WHERE ID = (SELECT ID FROM CONTEXT WHERE NAME = '"+tmp.Groups[1].ToString()+"')");
                List<string> temptags = new List<string>();

                while (dbresult.Read())
                {
                    temptags.Add(dbresult["Value"].ToString());
                }

                contexts.Add(new Context() { name = tmp.Groups[1].ToString(), tags = temptags });
                tmp = tmp.NextMatch();
            }

            DataAccess.DBConnector.closeConnection();

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
            BingSearch.startBingSearch(StringBuilder(), Results);
        }

        public string GetResults()
        {
            string result="";

            if (Results[0] != null)  //if the first cell of the array is null, there were no results from Bing!
            {
                foreach (Result r in Results)
                {
                    result += "<p><a href='" + r.displayURL + "' target='_blank'>" + r.title + "</a><p>" + r.description + "<br /><br />";
                }
            }
            else
                result = "<h2>No results<h2>";

            return result;

        }

    }
}