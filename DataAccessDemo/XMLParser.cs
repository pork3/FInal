using DataAccess.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DataAccessDemo
{
    public class XMLParser
    {
        public static List<Vegan> Parsetime(Stream vegandata)
        {

            XmlReader tidedoc = XmlReader.Create(vegandata);

            var isVegan = new List<Vegan>();
            Console.WriteLine(vegandata);
            using (tidedoc)
            {
                Vegan tide = null;

                while (tidedoc.Read())
                {
                    if (tidedoc.IsStartElement())
                    {
                        switch (tidedoc.Name)
                        {
                            case "item":
                              /*  tide = new Vegan();
                                break;  
                            case "time":
                                if (tidedoc.Read() && tide != null)
                                {
                                    tide.Time = tidedoc.Value.Trim();
                                    Console.WriteLine(tide.Time);
                                }
                                break;

                            case "pred":
                                if (tidedoc.Read() && tide != null)
                                {
                                    tide.Feet = tidedoc.Value.Trim();
                                    Console.WriteLine(tide.Feet + "ft");
                                }
                                break;
                            case "type":
                                if (tidedoc.Read() && tide != null)
                                {
                                    tide.HiLo = tidedoc.Value.Trim();
                                    Console.WriteLine(tide.HiLo);
                                }*/
                                break;

                        }
                    }
                }
            }


            return isVegan;
        }

    }
}
