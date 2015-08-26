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
        private String nome;
        private int idAnnuncio;
        private int idUtente = 0;
        private DB.Annuncio dbA = new DB.Annuncio();
        private DB.Utente dbU = new DB.Utente();
        protected bool isLoggato = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            nome = (String)(Session["nomeCognome"]);
            if ((Session["idUtente"]) != null)
                idUtente = (int)(Session["idUtente"]);

            if (Request.QueryString["idAnnuncio"] != null)
                idAnnuncio = Convert.ToInt32(Request.QueryString["idAnnuncio"]);
            else if ((Session["idAnnuncio"]) != null)
                idAnnuncio = (int)(Session["idAnnuncio"]);

            DB.Annuncio annuncio = dbA.GetAnnuncio(idAnnuncio);
            titoloLabel.Text = annuncio.Titolo;
            descrizioneLabel.Text = annuncio.Descrizione;
            cittaLabel.Text = annuncio.Citta;

            if (nome == null || idUtente == 0)
            {
                indirizzoLabel.Text = "Accedi o registrati per visualizzare l'indirizzo";
                telefonoLabel.Text = "Accedi o registrati per visualizzare il numero di telefono";
                emailLabel.Text = "Accedi o registrati per visualizzare l'email";

                //Response.BufferOutput = true;
                //Response.Redirect("~/Default.aspx", false);
            }
            else
            {
                isLoggato = true;
                indirizzoLabel.Text = annuncio.Indirizzo;
                telefonoLabel.Text = annuncio.Telefono;
                emailLabel.Text = dbU.GetEmail(annuncio.IdUtente);

                //popolo il Repeater
                List<string> listaFoto = dbA.getListaFotoDiAnnuncio(idAnnuncio);
                foto.DataSource = listaFoto; //può essere ad esempio un Array o una List di stringhe
                foto.DataBind();
            }


        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            Response.BufferOutput = true;
            Response.Redirect("~/Account/Profilo.aspx", false);
        }
    }
}