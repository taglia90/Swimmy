using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Swimmy
{
    public partial class Registrazione : Page
    {



        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String queryStr;

        System.Drawing.Color coloreTextBox;
        bool isProprietario;

        protected void Page_Load(object sender, EventArgs e)
        {
            coloreTextBox = txtUsername.ForeColor;
            //RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }



        protected void submitButton_Click(object sender, EventArgs e)
        {
            txtUsername.Text = txtEmail.Text;
            // registraUtente();
            registraUtenteConSlowHash();
            // MessageBox.Show("Registrazione avvenuta con successo.", "Registrazione OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /*     private bool controllaInputUtente(String inputUtente)
             {

                 var regExpression = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9]*$");
                 if (regExpression.IsMatch(inputUtente))
                 {
                     return true;
                 }
                 return false;
             }*/

        private void registraUtenteConSlowHash()
        {
            bool status = true;
            if (//InputValidation.ValidaNomeUtente(txtUsername.Text) == false
                 InputValidation.ValidaPassword(txtPassword1.Text, txtPassword2.Text) == false
                || InputValidation.ValidaNome(txtNome.Text) == false
                || InputValidation.ValidaNome(txtCognome.Text) == false
                || InputValidation.ValidaEmail(txtEmail.Text) == false
                //|| isUsernameUtilizzato()   //l'username è già usato da un altro utente.
                )
            {

                status = false;
            }

            if (status == true)
            {
                registraUtente();

            }
        }

        private bool isUsernameUtilizzato()    //verifico l'esistenza dell'username nel database
        {
            bool isUtilizzato;
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "SELECT username FROM swimmy.utente WHERE username=?uname";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("?uname", txtUsername.Text);

            reader = cmd.ExecuteReader();


            if (reader.HasRows)
            {
                isUtilizzato = true;    //il nome utente è già utilizzato
            }
            else
            {
                isUtilizzato = false;   //il nome utente è disponibile
            }

            reader.Close();
            conn.Close();

            return isUtilizzato;

        }

        private bool isEmailUtilizzata()    //verifico l'esistenza dell'email nel database
        {
            bool isUtilizzata;
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "SELECT email FROM swimmy.utente WHERE email=?email";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("?email", txtEmail.Text);

            reader = cmd.ExecuteReader();


            if (reader.HasRows)
            {
                isUtilizzata = true;    //l'email è già utilizzata
            }
            else
            {
                isUtilizzata = false;   //l'email è disponibile
            }

            reader.Close();
            conn.Close();

            return isUtilizzata;

        }


        private void registraUtente()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "INSERT INTO swimmy.utente (username, password, nome, cognome, email, isProprietario, citta, tipoUtente, sesso, posizioneLavorativa, datiPagamento)" +
                    "VALUES(?uname,?password,?nome,?cognome,?email,?isProprietario,'','','','','')";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("?uname", txtUsername.Text);
            cmd.Parameters.AddWithValue("?nome", txtNome.Text);
            cmd.Parameters.AddWithValue("?cognome", txtCognome.Text);
            cmd.Parameters.AddWithValue("?email", txtEmail.Text);

            isProprietarioChecked();
            cmd.Parameters.AddWithValue("?isProprietario", isProprietario);


            String saltHashReturend = PasswordHash.CreateHash(txtPassword1.Text);
            int commaIndex = saltHashReturend.IndexOf(":");
            String extractedString = saltHashReturend.Substring(0, commaIndex);
            commaIndex = saltHashReturend.IndexOf(":");
            extractedString = saltHashReturend.Substring(commaIndex + 1);
            commaIndex = extractedString.IndexOf(":");
            String salt = extractedString.Substring(0, commaIndex);

            commaIndex = extractedString.IndexOf(":");
            extractedString = extractedString.Substring(commaIndex + 1);
            String hash = extractedString;
            //Dal primo : al secondo : è il salt
            //Dal secondo : fino alla fine è l'hash
            cmd.Parameters.AddWithValue("?password", saltHashReturend);


            cmd.ExecuteReader();
            conn.Close();

            Response.BufferOutput = true;
            Response.Redirect("~/ConfermaRegistrazione.aspx", false);


        }

        protected void controllaUsername(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !isUsernameUtilizzato();
        }

        protected void controllaEmail(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !isEmailUtilizzata();
        }

        private void isProprietarioChecked()
        {
            if (RadioButton1.Checked == true)
            {
                isProprietario = true;
            }
            else
            {
                isProprietario = false;
            }
        }

    }
}