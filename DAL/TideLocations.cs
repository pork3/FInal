using System;
using SQLite;

namespace DAL
{
    //two different databases, one to store places
    //this one stores lat/long id and name of stations for 
    //rest services
    [Table("TideLocations")]
    public class TideLocations
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
         [MaxLength(8)]
        public string StationName{ get; set; }
        public string StationID{ get; set; }
        public string Latitude{ get; set; }
        public string Longitude{ get; set; }

    }
}