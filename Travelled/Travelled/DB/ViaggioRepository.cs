using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Travelled.Models;
using Travelled.Connections;

namespace Travelled.DB
{
    class ViaggioRepository
    {
        MySqlConnection connection = new MySqlConnection(DBConnection.getConnection());
        string COLONNA_ID = "id";
        string COLONNA_IDUSER = "id_user";
        string COLONNA_NAZIONE = "nazione";
        string COLONNA_CITTA = "citta";
        string COLONNA_DESCRIZIONE = "descrizione";
        string COLONNA_DATA = "data_viaggio";
        string TABELLA_VIAGGI = "visiteddb.viaggi";

        public Viaggio findUserViaggioById(int id)
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT " + COLONNA_ID + "," + COLONNA_IDUSER + "," + COLONNA_NAZIONE + ","
                                  + COLONNA_CITTA + "," + COLONNA_DESCRIZIONE + "," + COLONNA_DATA + " FROM " + TABELLA_VIAGGI 
                                  + " WHERE " + COLONNA_ID + "=@id";

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Viaggio viaggio = new Viaggio();

                viaggio.Id = (int)reader.GetUInt64("id");
                viaggio.Id_user = (int)reader.GetUInt64("id_user");
                viaggio.Nazione = reader.GetString("nazione");
                viaggio.Citta = reader.GetString("citta");
                viaggio.Descrizione = reader.GetString("descrizione");
                viaggio.Data_viaggio = reader.GetDateTime("data_viaggio");

                return viaggio;
            }

            return null;
        }


        public List<Viaggio> findAllViaggi()
        {
            List<Viaggio> allViaggi = new List<Viaggio>();
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT " + COLONNA_ID + "," + COLONNA_IDUSER + "," + COLONNA_NAZIONE + ","
                                  + COLONNA_CITTA + "," + COLONNA_DESCRIZIONE + "," + COLONNA_DATA+ " FROM " + TABELLA_VIAGGI;

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Viaggio viaggio = new Viaggio();

                viaggio.Id = (int)reader.GetUInt64("id");
                viaggio.Id_user = (int)reader.GetUInt64("id_user");
                viaggio.Nazione = reader.GetString("nazione");
                viaggio.Citta = reader.GetString("citta");
                viaggio.Descrizione = reader.GetString("descrizione");
                viaggio.Data_viaggio = reader.GetDateTime("data_viaggio");

                allViaggi.Add(viaggio);
            }

            return allViaggi;
        }


        public List<string> findAllNazioni()
        {
            List<string> allNazioni = new List<string>();
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT " + COLONNA_NAZIONE + " FROM " + TABELLA_VIAGGI;

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Viaggio viaggio = new Viaggio();

                viaggio.Nazione = reader.GetString("nazione");

                allNazioni.Add(viaggio.Nazione);
            }

            return allNazioni;
        }


        public List<Viaggio> findAllViaggiConStessoIdUser(int idUser)
        {
            List<Viaggio> allViaggiDiIdUser = new List<Viaggio>();

            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT " + COLONNA_ID + "," + COLONNA_IDUSER + "," + COLONNA_NAZIONE + ","
                                  + COLONNA_CITTA + "," + COLONNA_DESCRIZIONE + "," + COLONNA_DATA +
                                  " FROM " + TABELLA_VIAGGI + " WHERE " + COLONNA_IDUSER + "=@idUser";

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Viaggio viaggio = new Viaggio();

                viaggio.Id = (int)reader.GetUInt64("id");
                viaggio.Id_user = (int)reader.GetUInt64("id_user");
                viaggio.Nazione = reader.GetString("nazione");
                viaggio.Citta = reader.GetString("citta");
                viaggio.Descrizione = reader.GetString("descrizione");
                viaggio.Data_viaggio = reader.GetDateTime("data_viaggio");

                allViaggiDiIdUser.Add(viaggio);
            }

            return allViaggiDiIdUser;
        }


        public List<string> findAllNazioniConStessoIdUser(int idUser)
        {
            List<string> allNazioniDiIdUser = new List<string>();

            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT " + COLONNA_ID + "," + COLONNA_IDUSER + "," + COLONNA_NAZIONE + ","
                                  + COLONNA_CITTA + "," + COLONNA_DESCRIZIONE + "," + COLONNA_DATA +
                                  " FROM " + TABELLA_VIAGGI + " WHERE " + COLONNA_IDUSER + "=@idUser";

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Viaggio viaggio = new Viaggio();

                viaggio.Nazione = reader.GetString("nazione");

                allNazioniDiIdUser.Add(viaggio.Nazione);
            }

            return allNazioniDiIdUser;
        }



        public DateTime findDataDiUnViaggio(Viaggio viaggio)
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT " + COLONNA_DATA + " FROM " + TABELLA_VIAGGI;

            MySqlDataReader reader = command.ExecuteReader();
            
            viaggio.Data_viaggio = reader.GetDateTime("data_viaggio");

            return viaggio.Data_viaggio;
        }


        public int findIdUserDiUnViaggio(Viaggio viaggio)
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT " + COLONNA_IDUSER + " FROM " + TABELLA_VIAGGI;

            MySqlDataReader reader = command.ExecuteReader();

            viaggio.Id_user = (int)reader.GetInt64("id_user");

            return viaggio.Id_user;
        }


        
    }
}
