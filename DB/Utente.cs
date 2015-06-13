using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;

namespace Swimmy.DB
{
    public class Utente
    {

        //DB.DBConnect db = new DB.DBConnect();
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String queryStr;
        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();

        public string GetEmail(int idUtente)
        {

            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "SELECT email FROM utente WHERE idUtente=?idU";
            string email = "";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("?idU", idUtente);

            reader = cmd.ExecuteReader();


            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    email = reader.GetString(0);
                }
            }

            reader.Close();
            conn.Close();

            return email;
        }

        public void AggiornaUtente(int idUtente, string citta, string cap, string telefono)
        {

            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "UPDATE swimmy.utente SET citta=?citta, cap=?cap, telefono=?telefono WHERE idUtente=?idUtente";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("?idUtente", idUtente);
            cmd.Parameters.AddWithValue("?citta", citta);
            cmd.Parameters.AddWithValue("?cap", cap);
            cmd.Parameters.AddWithValue("?telefono", telefono);

            reader = cmd.ExecuteReader();

            reader.Close();
            conn.Close();

            return;
        }

    }
}