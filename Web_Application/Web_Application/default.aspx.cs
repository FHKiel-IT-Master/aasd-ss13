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
        private RequestHandler.Handler hld;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Handler"] = new RequestHandler.Handler();
                hld = Session["Handler"] as RequestHandler.Handler;

                LoadContext(hld.LoadStructure());
            }

        }

        protected void LoadContext(List<string> ctx)
        {
            for (int i = 0; i < ctx.Count; i++)
            {
                contexts.InnerHtml += "<input id='tl_" + ctx[i] + "' type='button' value='" + ctx[i] + "' class='btn_tile' onclick='context_clicked(this.value)'/>";
            }
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {

            hld = Session["Handler"] as RequestHandler.Handler;
            hld.RequestSearch(TxtB_Input.Text, hidContexts.Value);

            string topic = TxtB_Input.Text == "" ? "Error" : TxtB_Input.Text;

            //Redirect to the result page.
            Response.Redirect("s_results.aspx?topic=" + topic + "#!/page_results", true);
        }

        
    }
}