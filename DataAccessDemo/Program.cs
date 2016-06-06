// Example of using SQLite-net ORM
// Brian Bird, 5/20/13

using System;
using SQLite;
using System.IO;
using DataAccess.DAL;
using System.Linq;
using System.Collections.Generic;
using DAL;
using RestService;

namespace L2Ch3.ConsoleApp
{
	class Program
	{
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to SQLite Database entry");
            Console.WriteLine("writing ");
            string dbPath = @"../../../DataAccess-Android/Assets/vegan.db3";
            var db = new SQLiteConnection(dbPath);
            if (db.CreateTable<Vegan>() == 0)
            {
                // A table already exixts, delete any data it contains
                db.DeleteAll<Vegan>();
            }

            //AddData(db, "veg.txt");
            AddVegan(db, "new.csv","Vegan");
            

        }

        

        private static void AddData(SQLiteConnection db, string file)
        {
            const int NUMBER_OF_FIELDS = 4;

            TextParser parser = new TextParser("\n", NUMBER_OF_FIELDS);

            List<string[]> stringArray;
            stringArray = parser.ParseText(File.Open(@"../../../DataAccess-Android/DAL/" + file, FileMode.Open));

            //stringArray.RemoveAt(0);

            int pk = 0;

            foreach (string[] s in stringArray )
            {
                Console.WriteLine(pk++);
                pk += db.Insert(new Vegan()
                {
                    isVegan = s[1],
                    Name = s[0],
                });
            }

            if (pk % 100 == 0)
                Console.WriteLine("{0} {1} rows inserted", pk);

            Console.WriteLine ("{0} rows inserted", pk);
        }

        private static void AddVegan(SQLiteConnection db, string file, string Vegan)
        {
            const int NUMBER_OF_FIELDS = 1;

            TextParser parser = new TextParser("\n", NUMBER_OF_FIELDS);

            List<string[]> stringArray;
            stringArray = parser.ParseText(File.Open(@"../../../DataAccess-Android/DAL/" + file, FileMode.Open));

            //stringArray.RemoveAt(0);

            int pk = 0;

            foreach (string[] s in stringArray)
            {
                Console.WriteLine(pk++);
                pk += db.Insert(new Vegan()
                {
                    isVegan = Vegan,
                    Name = s[0],
                });
            }

            if (pk % 100 == 0)
                Console.WriteLine("{0} {1} rows inserted", pk);

            Console.WriteLine("{0} rows inserted", pk);
        }

        
	}
}
