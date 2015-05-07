using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Swimmy.Account
{
    public partial class Profilo : System.Web.UI.Page
    {
        String nome;

        protected void Page_Load(object sender, EventArgs e)
        {
            nome = (String)(Session["uname"]);

            if (nome == null)
            {
                Response.BufferOutput = true;
                Response.Redirect("~/Default.aspx", false);
            }
            else
            {
                userLabel.Text = nome;
            }
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Session["uname"] = null;
            Session.Abandon();
            Response.BufferOutput = true;
            Response.Redirect("~/Default.aspx", false);
        }
    }
}