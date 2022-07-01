using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace UMelusiTrack.Models
{
    public class OrderingModels
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Quantity { get; set; }
        public string Refence_number { get; set; }
        public string Delivery_options { get; set; }
        public string Delivery_address { get; set; }
        public string Contact_number { get; set; }
        public string Email_address { get; set; }
    }
}
