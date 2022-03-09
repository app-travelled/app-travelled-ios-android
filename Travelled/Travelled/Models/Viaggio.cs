using System;
using System.Collections.Generic;
using System.Text;

namespace Travelled.Models
{
    public class Viaggio
    {
        private int id;
        private int id_user;
        private DateTime data_viaggio;
        private string nazione;
        private string citta;
        private string descrizione;



        public int Id { get => id; set => id = value; }
        public int Id_user { get => id_user; set => id_user = value; }
        //add fine data viaggio
        public DateTime Data_viaggio { get => data_viaggio; set => data_viaggio = value; }
        public string Nazione { get => nazione; set => nazione = value; }
        public string Citta { get => citta; set => citta = value; }
        public string Descrizione { get => descrizione; set => descrizione = value; }
    }
}