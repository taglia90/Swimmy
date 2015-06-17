using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Swimmy.Account
{
    public partial class ModificaProfilo : System.Web.UI.Page
    {
        String nome;
        int idUtente;
        DB.Utente dbU = new DB.Utente();

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
                emailLabel.Text = dbU.GetEmail(idUtente);
                DB.Utente utente = dbU.GetUtente(idUtente);
                txtCitta.Text = utente.Citta;
                txtCap.Text = utente.Cap;
                txtNumeroTelefono.Text = utente.Telefono;
            }
        }



        protected void submitButton_Click(object sender, EventArgs e)
        {
            dbU.AggiornaUtente(idUtente, txtCitta.Text, txtCap.Text, txtNumeroTelefono.Text);
            Response.BufferOutput = true;
            Response.Redirect("~/Account/Profilo.aspx", false);
        }

        /* protected void logoutButton_Click(object sender, EventArgs e)
         {
             Session["nomeCognome"] = null;
             Session["idUtente"] = null;
             Session.Abandon();
             Response.BufferOutput = true;
             Response.Redirect("~/Default.aspx", false);
         }*/
    }
}