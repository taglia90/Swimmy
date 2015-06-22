using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Swimmy.Annuncio
{
    public partial class ListaAnnunci : System.Web.UI.Page
    {
        private String nome;
        private int idUtente = 0;
        private DB.Annuncio dbA = new DB.Annuncio();
        protected List<DB.Annuncio> listaAnnunci = new List<DB.Annuncio>();

        protected void Page_Load(object sender, EventArgs e)
        {
            nome = (String)(Session["nomeCognome"]);
            if ((Session["idUtente"]) != null)
                idUtente = (int)(Session["idUtente"]);            
               
            if (nome == null || idUtente == 0)
            {
                Response.BufferOutput = true;
                Response.Redirect("~/Default.aspx", false);
            }
            else
            {
                listaAnnunci = new List<DB.Annuncio>();
                listaAnnunci = dbA.getListaAnnunciDiUtente(idUtente);
                listaAnnunciView.DataSource = listaAnnunci; //può essere ad esempio un Array o una List di stringhe
                listaAnnunciView.DataBind();
               
            }


        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            Response.BufferOutput = true;
            Response.Redirect("~/Account/Profilo.aspx", false);
        }
    }
}