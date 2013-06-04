using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace RequestHandler
{
    public class Handler
    {
        private SearchSystem.Search srch;

        public void RequestSearch(string input, string context)
        {
            //Firstly create a new search instance
            srch = new SearchSystem.Search(input, context);

            //Secondly start the search process
            srch.WebSearchProcess();

            //Need to define some things before uncommenting these lines (Class Diagram)
            //Thirdly refine the results
            //SearchSystem.Refiner refine = new SearchSystem.Refiner(srch.contexts);
            //refine.Refine(srch.aResults);
        }

        public string RequestResults()
        {
            return srch.GetResults();
        }

        public List<string> LoadStructure()
        {
            //Here the connector to the database comes into play.
            //It will output an array of strings containing the "structure"
            //Here is just an example

            DataAccess.DBConnector db = new DataAccess.DBConnector();
            SqlDataReader results = db.executeQuery("SELECT Name FROM CONTEXT");

            List<string> ctxs = new List<string>();

            while (results.Read())
            {
                ctxs.Add(results["Name"].ToString());
            }

            return ctxs;
        }
        
    }
}