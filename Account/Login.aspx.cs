using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Swimmy.Account
{
    public partial class Login : Page
    {




        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String queryStr;
        //String nome;

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }


        protected void submitButton_Click(object sender, EventArgs e)
        {

            loginConHash();

        }

        private void loginConHash()
        {
            List<String> saltHashList = null;
            List<String> listaNomi = null;
            try
            {
                String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();
                conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
                conn.Open();
                queryStr = "SELECT * FROM swimmy.utente WHERE username=?uname";

                cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("?uname", txtUsername.Text);
                reader = cmd.ExecuteReader();

                while (reader.HasRows && reader.Read())
                {
                    if (saltHashList == null)
                    {
                        saltHashList = new List<String>();
                        listaNomi = new List<String>();
                    }

                    String saltHsahes = reader.GetString(reader.GetOrdinal("password"));
                    saltHashList.Add(saltHsahes);
                    String nomeCognome = reader.GetString(reader.GetOrdinal("nome")) +" "+ reader.GetString(reader.GetOrdinal("cognome"));
                    listaNomi.Add(nomeCognome);
                }
                reader.Close();
                if (saltHashList != null)
                {
                    for (int i = 0; i < saltHashList.Count; i++)
                    {
                        queryStr = "";
                        bool validUser = PasswordHash.ValidatePassword(txtPassword.Text, saltHashList[i]);
                        if (validUser == true)
                        {
                            Session["uname"] = listaNomi[i];
                            Response.BufferOutput = true;
                            Response.Redirect("Profilo.aspx", false);

                        }
                        else
                        {
                            //autenticazione fallita
                        }
                    }
                }
          
            }
            catch(Exception ex)
            {

            }
        }

      /*  private void login()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "SELECT * FROM swimmy.utente WHERE username=?uname AND password=?password";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("?uname", txtUsername.Text);
            cmd.Parameters.AddWithValue("?password", txtPassword.Text);

            reader = cmd.ExecuteReader();
            nome = "";

            while (reader.HasRows && reader.Read())
            {
                nome = reader.GetString(reader.GetOrdinal("nome"));
            }

            if (reader.HasRows)
            {
                Session["uname"] = nome;
                Response.BufferOutput = true;
                Response.Redirect("Profilo.aspx", false);

            }
            else
            {
                //username o password non validi.
            }

            reader.Close();
            conn.Close();


        }

        */


    }
}