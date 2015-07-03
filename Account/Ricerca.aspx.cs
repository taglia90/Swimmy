using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace Swimmy.Account
{
    public partial class Ricerca : System.Web.UI.Page
    {
        private String nome;
        private int idUtente = 0;
        private DB.Annuncio dba = new DB.Annuncio();
        protected List<DB.Annuncio> listaAnnunci = new List<DB.Annuncio>();

        protected void Page_Load(object sender, EventArgs e)
        {
            nome = (String)(Session["nomeCognome"]);
            if ((Session["idUtente"]) != null)
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
            GetAnnunci();
            lblRisultato.Visible = true;
        }


        protected void popolaProvinciaDDL(object sender, EventArgs e)
        {
            List<string> listaProvince = dba.GetProvinceDaRegione(regioneDDL.Text);
            provinciaDDL.Items.Insert(0, "--Inserisci la provincia--");
            provinciaDDL.DataSource = listaProvince;
            provinciaDDL.DataBind();
            GetAnnunci();
            lblRisultato.Visible = true;
        }

        public List<DB.Annuncio> GetAnnunci()
        {
            listaAnnunci = new List<DB.Annuncio>();
            listaAnnunci = dba.getListaAnnunci(regioneDDL.Text, provinciaDDL.Text, txtCitta.Text);
            listaAnnunciView.DataSource = listaAnnunci; //può essere ad esempio un Array o una List di stringhe
            listaAnnunciView.DataBind();

            return listaAnnunci;
        }
    }
}