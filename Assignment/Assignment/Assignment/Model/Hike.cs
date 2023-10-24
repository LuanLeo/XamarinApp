using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Model
{
    public class Hike
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Parking { get; set; }
        public string Length { get; set; }
        public string Level { get; set; }
        public string FQuantity { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
    }
}
