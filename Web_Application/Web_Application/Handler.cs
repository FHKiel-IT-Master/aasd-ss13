using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Application
{
    public class Handler
    {
        private Search srch;

        public void RequestSearch(string input, string context)
        {
            //First create a new search instance
            srch = new Search(input,context);

            //Secondly start the search process
            srch.WebSearchProcess();
        }

        public string RequestResults()
        {
            return srch.GetResults();
        }

        public string [] LoadStructure()
        {
            //Here the connector to the database comes into play.
            //It will output an array of strings containing the "structure"
            //Here is just an example

            string[] ctxs = new String[10];
            ctxs[0] = "News"; ctxs[1] = "Sports"; ctxs[2] = "Music"; ctxs[3] = "Person"; ctxs[4] = "Country"; ctxs[5] = "Technology";
            ctxs[6] = "University"; ctxs[7] = "Clubs"; ctxs[8] = "Party"; ctxs[9] = "Magazines";

            return ctxs;
        }
        
    }
}