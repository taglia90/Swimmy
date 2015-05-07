using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Swimmy.DB
{
    public class DBUtente
    {

        

        public DBUtente() {
        
        }


    /*    public static void InsertInUtente(String username)
        {
            string query = "INSERT INTO swimmy.utente (username, password, nome, cognome) VALUES('" + username + "', 'asdasd','Marco', 'Taglia')";
            DBConnect conn = new DBConnect();

            //open connection
            if (conn.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                conn.CloseConnection();
            }
        }*/


    }
}