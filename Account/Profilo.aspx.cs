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
        int idUtente;

        protected void Page_Load(object sender, EventArgs e)
        {
            nome = (String)(Session["nomeCognome"]);
            idUtente = (int)(Session["idUtente"]);

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

        protected void modificaProfiloButton_Click(object sender, EventArgs e)
        {
            Response.BufferOutput = true;
            Response.Redirect("~/Account/ModificaProfilo.aspx", false);
        }


        protected void inserisciAnnuncioButton_Click(object sender, EventArgs e)
        {
            Response.BufferOutput = true;
            Response.Redirect("~/Annuncio/InserisciAnnuncio.aspx", false);
        }

        protected void ricercaButton_Click(object sender, EventArgs e)
        {
            Response.BufferOutput = true;
            Response.Redirect("~/Account/Ricerca.aspx", false);
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