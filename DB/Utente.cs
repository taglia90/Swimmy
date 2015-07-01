using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;

namespace Swimmy.DB
{
    public class Utente
    {

        private int idUtente;
        private string username;
        private string nome;
        private string cognome;
        private string email;
        private string citta;
        private string cap;
        private string sesso;
        private bool isProprietario;
        private string telefono;


        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String queryStr;
        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();

        public Utente GetUtente(int idUtente)
        {

            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "SELECT * FROM utente WHERE idUtente=?idU";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("?idU", idUtente);

            reader = cmd.ExecuteReader();
            Utente u = new Utente();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    u.IdUtente = idUtente;

                    u.Username = reader["username"].ToString();
                    u.Nome = reader["nome"].ToString();
                    u.Cognome = reader["cognome"].ToString();
                    u.Email = reader["email"].ToString();
                    u.Citta = reader["citta"].ToString();
                    u.Cap = reader["cap"].ToString();
                    u.Sesso = reader["sesso"].ToString();
                    u.IsProprietario = Convert.ToBoolean(reader["isProprietario"]);
                    u.Telefono = reader["telefono"].ToString();

                }
            }

            reader.Close();
            conn.Close();

            return u;
        }


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

        #region getters & setters
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public bool IsProprietario
        {
            get { return isProprietario; }
            set { isProprietario = value; }
        }

        public string Sesso
        {
            get { return sesso; }
            set { sesso = value; }
        }

        public string Cap
        {
            get { return cap; }
            set { cap = value; }
        }

        public string Citta
        {
            get { return citta; }
            set { citta = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Cognome
        {
            get { return cognome; }
            set { cognome = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public int IdUtente
        {
            get { return idUtente; }
            set { idUtente = value; }
        }
        #endregion
    }
}