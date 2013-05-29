using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Application
{
    public partial class s_results : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["topic"] == "Error")
            {
                ResultsLiteral.Text = "<h2> Error! <br/> Please fill in the search input</h2>";
            }
            else
            {
                //Get the Search instance for that session
                Search srch = Session["SearchObj"] as Search;

                SearchTopic.Text = "<h3> You searched for:" + Request["topic"] + "</h3>";
                ResultsLiteral.Text = "<p>" + srch.GetResults() + "</p>";
            }
        }
    }
}