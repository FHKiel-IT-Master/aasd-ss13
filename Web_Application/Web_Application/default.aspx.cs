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
        private Handler hld;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Create a new Handler session.
                Session["Handler"] = new Handler();

                hld = Session["Handler"] as Handler;

                //Asks the handler for the structure and load the contexts
                LoadContext(hld.LoadStructure());

            }

        }

        //Receives a array of strings to dynamically insert HTML into the contexts div
        protected void LoadContext(string[] ctx)
        {
            for (int i = 0; i < ctx.Length; i++)
            {
                contexts.InnerHtml += "<input id='tl_" + ctx[i] + "' type='button' value='" + ctx[i] + "' class='btn_tile' onclick='context_clicked(this.value)'/>";
                subcontexts.InnerHtml += "<input id='sub_" + ctx[i] + "' name='tl_" + ctx[i] + "_sub' type='button' value='SUB' class='btn_tile sub' onclick='subcontext_clicked(this.value)' style='display:none;'/>";
                subcontexts.InnerHtml += "<input id='sub_" + ctx[i] + "' name='tl_test_sub' type='button' value='SUB' class='btn_tile sub' onclick='subcontext_clicked(this.id,this.value)' style='display:none;'/>";
            }
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {

            hld = Session["Handler"] as Handler;
            hld.RequestSearch(TxtB_Input.Text, Hidden1.Value);

            string topic = TxtB_Input.Text == "" ? "Error" : TxtB_Input.Text;

            //Redirect to the result page.
            Response.Redirect("s_results.aspx?topic="+topic+Hidden1.Value+"#!/page_results", true);
        }

        
    }
}