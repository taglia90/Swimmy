using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Swimmy.Account
{
    public partial class Ricerca : System.Web.UI.Page
    {
        String nome;
        int idUtente = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            nome = (String)(Session["nomeCognome"]);
            if ((Session["idUtente"])!=null)
                idUtente = (int)(Session["idUtente"]);

            if (nome == null || idUtente == 0)
            {
                //Response.BufferOutput = true;
                //Response.Redirect("~/Default.aspx", false);
            }
            else
            {
                //userLabel.Text = nome;
            }
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            //   dbU.AggiornaUtente(idUtente, txtCitta.Text, txtCap.Text, txtNumeroTelefono.Text);
            //  Response.BufferOutput = true;
            //  Response.Redirect("~/Account/Profilo.aspx", false);
        }
    }
}