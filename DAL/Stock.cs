using System;
using SQLite;

namespace DataAccess.DAL
{
    public class Vegan
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(8)]
        public string Name { get; set;  }
        public string isVegan { get; set; }
    }
}