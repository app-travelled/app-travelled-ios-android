using System;
using System.Collections.Generic;
using System.Text;

namespace Travelled.Models
{
    public class User
    {
        //su database
        private int id;
        private string username;
        private string password;
        private string email;
        //non su database
        private List<Viaggio> viaggi;


        public string Password { get => password; set => password = value; }
        public List<Viaggio> Viaggi { get => viaggi; set => viaggi = value; }
        public string Username { get => username; set => username = value; }
        public string Email { get => email; set => email = value; }
        public int Id { get => id; set => id = value; }



    }
}