using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Swimmy.Account
{
    public partial class ConfermaRegistrazione : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void redirectToIndex_Click(object sender, EventArgs e)
        {

            Response.BufferOutput = true;
            Response.Redirect("~/Default.aspx", false);
        }
    }
}