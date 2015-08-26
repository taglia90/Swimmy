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
        private string regione;
        private string provincia;
        private string citta;
        private string indirizzo;
        private string telefono;
        private string urlFotoPrincipale;

        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String queryStr;
        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();

        public Annuncio()
        {

        }

        public int InserisciAnnuncio(int idUtente, string titolo, string descrizione, string regione, string provincia, string citta, string indirizzo, string telefono)
        {

            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "INSERT INTO swimmy.annuncio (idUtente, titolo, descrizione, regione, provincia, citta, indirizzo, telefono) VALUES(?idu, ?titolo,?descr, ?reg, ?pro, ?citta, ?indirizzo, ?telefono);" +
                "SELECT LAST_INSERT_ID();";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("?idu", idUtente);
            cmd.Parameters.AddWithValue("?titolo", titolo);
            cmd.Parameters.AddWithValue("?descr", descrizione);
            cmd.Parameters.AddWithValue("?reg", regione);
            cmd.Parameters.AddWithValue("?pro", provincia);
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

        public Annuncio GetAnnuncio(int idAnnuncio)
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

                    a.IdUtente = Convert.ToInt32(reader["idUtente"]);
                    a.Titolo = reader["titolo"].ToString();
                    a.Descrizione = reader["descrizione"].ToString();
                    a.Regione = reader["regione"].ToString();
                    a.Provincia = reader["provincia"].ToString();
                    a.Citta = reader["citta"].ToString();
                    a.Indirizzo = reader["indirizzo"].ToString();
                    a.Telefono = reader["telefono"].ToString();

                }
            }

            reader.Close();
            conn.Close();

            return a;
        }

        public int InserisciFoto(int idUtente, int idAnnuncio, string urlFoto)
        {

            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "INSERT INTO swimmy.foto (idUtente, idAnnuncio, urlFoto) VALUES(?idu, ?ida,?url);" +
                "SELECT LAST_INSERT_ID();";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("?idu", idUtente);
            cmd.Parameters.AddWithValue("?ida", idAnnuncio);
            cmd.Parameters.AddWithValue("?url", urlFoto);

            reader = cmd.ExecuteReader();


            int idFoto = -1;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    idFoto = reader.GetInt32(0);
                }
            }

            reader.Close();
            conn.Close();

            return idFoto;
        }

        public List<string> getListaFotoDiAnnuncio(int idAnnuncio)
        {

            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "SELECT urlFoto FROM swimmy.foto WHERE idAnnuncio=?ida;";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("?ida", idAnnuncio);

            reader = cmd.ExecuteReader();

            List<string> listaFoto = new List<string>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listaFoto.Add(reader["urlFoto"].ToString());
                }
            }

            reader.Close();
            conn.Close();

            return listaFoto;
        }



        public List<string> GetProvinceDaRegione(string regione)
        {

            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "SELECT provincia FROM swimmy.regione_province WHERE regione=?reg;";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("?reg", regione);

            reader = cmd.ExecuteReader();

            List<string> province = new List<string>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    province.Add(reader.GetString(0));
                }
            }

            reader.Close();
            conn.Close();

            return province;
        }

        public List<Annuncio> getListaAnnunci(string regione, string provincia, string citta)
        {

            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            //queryStr = "SELECT * FROM swimmy.annuncio WHERE regione=?reg AND provincia LIKE ?pro AND citta LIKE ?cit;";

            queryStr = "SELECT a.*, f.urlFoto FROM swimmy.annuncio a LEFT JOIN swimmy.foto f" +
" ON a.idAnnuncio = f.idAnnuncio" +
" WHERE regione=?reg AND provincia LIKE ?pro AND citta LIKE ?cit" +
" GROUP BY a.idAnnuncio;";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("?reg", regione);
            cmd.Parameters.AddWithValue("?pro", "%" + provincia + "%");
            cmd.Parameters.AddWithValue("?cit", "%" + citta + "%");

            reader = cmd.ExecuteReader();

            List<Annuncio> listaAnnunci = new List<Annuncio>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var annuncio = new Annuncio();
                    annuncio.IdAnnuncio = Convert.ToInt32(reader["idAnnuncio"]);
                    annuncio.IdUtente = Convert.ToInt32(reader["idUtente"]);
                    annuncio.Titolo = reader["titolo"].ToString();
                    annuncio.Descrizione = reader["descrizione"].ToString();
                    annuncio.Regione = reader["regione"].ToString();
                    annuncio.Provincia = reader["provincia"].ToString();
                    annuncio.Citta = reader["citta"].ToString();
                    annuncio.Indirizzo = reader["indirizzo"].ToString();
                    annuncio.Telefono = reader["telefono"].ToString();
                    annuncio.UrlFotoPrincipale = reader["urlFoto"].ToString();

                    listaAnnunci.Add(annuncio);
                }
            }

            reader.Close();
            conn.Close();

            return listaAnnunci;
        }

        public List<Annuncio> getListaAnnunciDiUtente(int idUtente)
        {

            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();

            queryStr = "SELECT a.*, f.urlFoto FROM swimmy.annuncio a LEFT JOIN swimmy.foto f" +
" ON a.idAnnuncio = f.idAnnuncio" +
" WHERE a.idUtente=?idu" +
" GROUP BY a.idAnnuncio;";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("?idu", idUtente);

            reader = cmd.ExecuteReader();

            List<Annuncio> listaAnnunci = new List<Annuncio>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var annuncio = new Annuncio();
                    annuncio.IdAnnuncio = Convert.ToInt32(reader["idAnnuncio"]);
                    annuncio.IdUtente = Convert.ToInt32(reader["idUtente"]);
                    annuncio.Titolo = reader["titolo"].ToString();
                    annuncio.Descrizione = reader["descrizione"].ToString();
                    annuncio.Regione = reader["regione"].ToString();
                    annuncio.Provincia = reader["provincia"].ToString();
                    annuncio.Citta = reader["citta"].ToString();
                    annuncio.Indirizzo = reader["indirizzo"].ToString();
                    annuncio.Telefono = reader["telefono"].ToString();
                    annuncio.UrlFotoPrincipale = reader["urlFoto"].ToString();

                    listaAnnunci.Add(annuncio);
                }
            }

            reader.Close();
            conn.Close();

            return listaAnnunci;
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

        public string Regione
        {
            get { return regione; }
            set { regione = value; }
        }

        public string Provincia
        {
            get { return provincia; }
            set { provincia = value; }
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

        public string UrlFotoPrincipale
        {
            get { return urlFotoPrincipale; }
            set { urlFotoPrincipale = value; }
        }


        #endregion
    }
}