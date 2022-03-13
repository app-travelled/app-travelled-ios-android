using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Travelled.Models;
using Travelled.Connections;

namespace Travelled.DB
{
    public class UserRepository
    {
        MySqlConnection connection = new MySqlConnection(DBConnection.getConnection());
        string COLONNA_ID = "id";
        string COLONNA_USERNAME = "username";
        string COLONNA_PASSWORD = "password";
        string COLONNA_EMAIL = "email";
        string TABELLA_USER = "visiteddb.user";


        public User findUserById(int id)
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT " + COLONNA_ID + "," + COLONNA_USERNAME + "," + COLONNA_PASSWORD + "," + COLONNA_EMAIL + " FROM "
                                  + TABELLA_USER + " WHERE " + COLONNA_ID + "=@id";

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                User user = new User();

                user.Id = (int)reader.GetUInt64("id");
                user.Username = reader.GetString("username");
                user.Password = reader.GetString("password");
                user.Email = reader.GetString("email");

                return user;
            }

            return null;
        }


        public List<User> findAllUsers()
        {
            List<User> allUsers = new List<User>();
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT " + COLONNA_ID + "," + COLONNA_USERNAME + "," + COLONNA_PASSWORD + "," + COLONNA_EMAIL + " FROM " + TABELLA_USER;

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                User user = new User();

                user.Id = (int)reader.GetUInt64("id");
                user.Username = reader.GetString("username");
                user.Password = reader.GetString("password");
                user.Email = reader.GetString("email");

                allUsers.Add(user);

            }

            return allUsers;
        }


        public User findByUsernameAndPassword(string password, string username)
        {
            User user = null;

            string query = "SELECT " + COLONNA_ID + "," + COLONNA_USERNAME + "," + COLONNA_PASSWORD + "," + COLONNA_EMAIL + " FROM " + TABELLA_USER +
                                    " WHERE " + COLONNA_PASSWORD + "=@password AND " + COLONNA_USERNAME + "=@username";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("@password", MySqlDbType.String);
            command.Parameters["@password"].Value = password;

            command.Parameters.Add("@username", MySqlDbType.String);
            command.Parameters["@username"].Value = username;

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    user = new User();
                    user.Id = (int)reader.GetUInt64("id");
                    user.Username = reader.GetString("username");
                    user.Password = reader.GetString("password");
                    user.Email = reader.GetString("email");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return user;
        }


        public User findById(int id)
        {
            User user = null;

            string query = "SELECT " + COLONNA_ID + "," + COLONNA_USERNAME + "," + COLONNA_PASSWORD + "," + COLONNA_EMAIL + " FROM " + TABELLA_USER +
                            " WHERE " + COLONNA_ID + "=@id";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("@id", MySqlDbType.Int64);
            command.Parameters["@id"].Value = id;

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    user = new User();
                    user.Id = (int)reader.GetUInt64("id");
                    user.Username = reader.GetString("username");
                    user.Password = reader.GetString("password");
                    user.Email = reader.GetString("email");


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return user;
        }


        public Boolean addUser(User newUser)
        {
            string query = "INSERT INTO " + TABELLA_USER + "(" + COLONNA_USERNAME + "," + COLONNA_PASSWORD + "," + COLONNA_EMAIL + ") values (@username, @password,@email)";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("@username", MySqlDbType.String);
            command.Parameters["@username"].Value = newUser.Username;

            command.Parameters.Add("@password", MySqlDbType.String);
            command.Parameters["@password"].Value = newUser.Password;

            command.Parameters.Add("@email", MySqlDbType.String);
            command.Parameters["@email"].Value = newUser.Email;

            try
            {
                connection.Open();
                int rowAffected = command.ExecuteNonQuery();
                if (rowAffected == 1)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }


        public Boolean deleteUser(User oldUser)
        {
            string query = "DELETE FROM" + TABELLA_USER + " WHERE " + COLONNA_ID + "=@id";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("@id", MySqlDbType.Int64);
            command.Parameters["@id"].Value = oldUser.Id;

            try
            {
                connection.Open();
                int rowAffected = command.ExecuteNonQuery();
                if (rowAffected == 1)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }


        public Boolean updateUser(User newUser)
        {
            string query = "UPDATE " + TABELLA_USER + " SET " + COLONNA_USERNAME + "=@username, " + COLONNA_PASSWORD + "=@password" + COLONNA_EMAIL + "=@email" +" WHERE " + COLONNA_ID + "=@id";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("@id", MySqlDbType.Int64);
            command.Parameters["@id"].Value = newUser.Id;

            command.Parameters.Add("@username", MySqlDbType.String);
            command.Parameters["@username"].Value = newUser.Username;

            command.Parameters.Add("@password", MySqlDbType.String);
            command.Parameters["@password"].Value = newUser.Password;

            command.Parameters.Add("@email", MySqlDbType.String);
            command.Parameters["@email"].Value = newUser.Email;

            try
            {
                connection.Open();
                int rowAffected = command.ExecuteNonQuery();
                if (rowAffected == 1)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

    }
}