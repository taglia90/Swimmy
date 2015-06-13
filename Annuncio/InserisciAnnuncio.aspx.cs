using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Swimmy.Account
{
    public partial class InserisciAnnuncio : System.Web.UI.Page
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
                //userLabel.Text = nome;
            }
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            DB.Annuncio dbAnnuncio = new DB.Annuncio();
            Session["idAnnuncio"] = dbAnnuncio.InserisciAnnuncio(idUtente, txtTitolo.Text, txtDescrizione.Text, txtCitta.Text, txtIndirizzo.Text, txtTelefono.Text);

            Response.BufferOutput = true;
            Response.Redirect("~/Annuncio/Annuncio.aspx", false);
        }

    }
}