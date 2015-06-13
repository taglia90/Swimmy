using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;

namespace Swimmy.DB
{
    public class Annuncio
    {

        private int idAnnuncio;
        private int idUtente;
        private string titolo;
        private string descrizione;
        private string citta;
        private string indirizzo;
        private string telefono;


        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String queryStr;
        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();

        public Annuncio()
        {

        }

        public int InserisciAnnuncio(int idUtente, string titolo, string descrizione, string citta, string indirizzo, string telefono)
        {

            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "INSERT INTO swimmy.annuncio (idUtente, titolo, descrizione, citta, indirizzo, telefono) VALUES(?idu, ?titolo,?descr, ?citta, ?indirizzo, ?telefono);" +
                "SELECT LAST_INSERT_ID();";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("?idu", idUtente);
            cmd.Parameters.AddWithValue("?titolo", titolo);
            cmd.Parameters.AddWithValue("?descr", descrizione);
            cmd.Parameters.AddWithValue("?citta", citta);
            cmd.Parameters.AddWithValue("?indirizzo", indirizzo);
            cmd.Parameters.AddWithValue("?telefono", telefono);

            reader = cmd.ExecuteReader();


            int idAnnuncio = -1;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    idAnnuncio = reader.GetInt32(0);
                }
            }

            reader.Close();
            conn.Close();

            return idAnnuncio;
        }

        public  Annuncio GetAnnuncio(int idAnnuncio)
        {

            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "SELECT * FROM swimmy.annuncio WHERE idAnnuncio=?idA;";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("?idA", idAnnuncio);

            reader = cmd.ExecuteReader();

            Annuncio a = new Annuncio();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    a.IdAnnuncio = idAnnuncio;
                    a.IdUtente = reader.GetInt32(1);
                    a.Titolo = reader.GetString(2);
                    a.Descrizione = reader.GetString(3);
                    a.Citta = reader.GetString(4);
                    a.Indirizzo = reader.GetString(5);
                    a.Telefono = reader.GetString(6);
                }
            }

            reader.Close();
            conn.Close();

            return a;
        }



        #region getters & setters

        public int IdAnnuncio
        {
            get { return idAnnuncio; }
            set { idAnnuncio = value; }
        }

        public int IdUtente
        {
            get { return idUtente; }
            set { idUtente = value; }
        }

        public string Titolo
        {
            get { return titolo; }
            set { titolo = value; }
        }


        public string Descrizione
        {
            get { return descrizione; }
            set { descrizione = value; }
        }


        public string Citta
        {
            get { return citta; }
            set { citta = value; }
        }


        public string Indirizzo
        {
            get { return indirizzo; }
            set { indirizzo = value; }
        }


        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        #endregion
    }
}