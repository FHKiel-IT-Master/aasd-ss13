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

            //Thirdly refine the results
            SearchSystem.Refiner refine = new SearchSystem.Refiner(srch.contexts, input);
            refine.Refine(srch.Results);
        }

        public string RequestResults()
        { 
            return srch.GetResults();
        }

        public List<string> LoadStructure()
        {
            DataAccess.DBConnector.openConnection();
            SqlDataReader results = DataAccess.DBConnector.executeQuery("SELECT Name FROM CONTEXT");

            List<string> ctxs = new List<string>();

            while (results.Read())
            {
                ctxs.Add(results["Name"].ToString());
            }

            DataAccess.DBConnector.closeConnection();

            return ctxs;
        }
        
    }
}