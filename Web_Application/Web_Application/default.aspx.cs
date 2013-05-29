using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Application
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Here the connector to the database comes into play.
                //It will output an array of strings containing the "structure"
                //Here is just an example

                string[] ctxs = new String[10];
                ctxs[0] = "News"; ctxs[1] = "Sports"; ctxs[2] = "Music"; ctxs[3] = "Person"; ctxs[4] = "Country"; ctxs[5] = "Technology";
                ctxs[6] = "University"; ctxs[7] = "Clubs"; ctxs[8] = "Party"; ctxs[9] = "Magazines";

                LoadContext(ctxs);
            }

        }

        //Receives a array of strings to dynamically insert HTML into the contexts div
        protected void LoadContext(string[] ctx)
        {
            for (int i = 0; i < ctx.Length; i++)
            {
                contexts.InnerHtml += "<input id='tl_" + ctx[i] + "' type='button' value='" + ctx[i] + "' class='btn_tile' onclick='context_clicked(this.value)'/>";
            }
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            //Create a new Search session.
            Search srch = (Search)Session["SearchObj"];
            Session["SearchObj"] = new Search(TxtB_Input.Text);

            string topic = TxtB_Input.Text == "" ? "Error" : TxtB_Input.Text;
            
            //Call the search class / refinement.

            //Redirect to the result page.
            Response.Redirect("s_results.aspx?topic="+topic+Hidden1.Value+"#!/page_results", true);
        }

        
    }
}