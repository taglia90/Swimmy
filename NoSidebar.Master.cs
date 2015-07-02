using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Swimmy
{
    public partial class NoSidebarMaster : MasterPage
    {
        protected bool isLoggato = false;
        private int idUtente = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["idUtente"]) != null)
            {
                isLoggato = true;
            }

        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Session["nomeCognome"] = null;
            Session["idUtente"] = null;
            Session.Abandon();
            Response.BufferOutput = true;
            Response.Redirect("~/Default.aspx", false);
        }
    }


}