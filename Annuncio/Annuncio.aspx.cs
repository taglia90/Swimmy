using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Swimmy.Annuncio
{
    public partial class Annuncio : System.Web.UI.Page
    {
        String nome;
        int idAnnuncio;
        int idUtente;
        DB.Annuncio dbA = new DB.Annuncio();
        DB.Utente dbU = new DB.Utente();

        protected void Page_Load(object sender, EventArgs e)
        {
            nome = (String)(Session["nomeCognome"]);
            idUtente = (int)(Session["idUtente"]);
            idAnnuncio = (int)(Session["idAnnuncio"]);

            if (nome == null)
            {
                Response.BufferOutput = true;
                Response.Redirect("~/Default.aspx", false);
            }
            else
            {
                DB.Annuncio annuncio = dbA.GetAnnuncio(idAnnuncio);
                titoloLabel.Text = annuncio.Titolo;
                descrizioneLabel.Text = annuncio.Descrizione;
                cittaLabel.Text = annuncio.Citta;
                indirizzoLabel.Text = annuncio.Indirizzo;
                telefonoLabel.Text = annuncio.Telefono;
                emailLabel.Text = dbU.GetEmail(idUtente);
            }
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            Response.BufferOutput = true;
            Response.Redirect("~/Account/Profilo.aspx", false);
        }
    }
}