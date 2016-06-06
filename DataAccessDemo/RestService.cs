using DataAccess.DAL;
using DataAccessDemo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;


namespace RestService
{
    public class VegRest
    {
        public void veganhpe()
       // public List<Vegan> veganhope()
        {
            //website veganhope
            // Set up the URL for querying the service
            string serviceUrl = "http://www.ihopeitsvegan.com/ingredients.html";
                       
           // string theRequest = string.Format("{0}?stationId={1}&beginDate={2}&endDate={3}&datum=MLLW&unit=0&timeZone=0&format=xml&Submit=Submit", serviceUrl, stationID, begin, end);
            // Send a request to the service and get a response
            var request = HttpWebRequest.Create(serviceUrl);
            var response = (HttpWebResponse)request.GetResponse();

            // Read and parse the response
            Stream reader = response.GetResponseStream();

            //var content = reader.ReadToEnd();
            //return Stream.Parsetime(reader).ToList();
        }
    }
}


//date format: 20160624

//?stationId=8454000&beginDate=20160524
//&endDate=20160624&datum=MLLW&unit=0&
//timeZone=0&format=html&Submit=Submit
//string theRequest = string.Format("{0}?stationId={1}&beginDate={2}&endDate={3}&datum=MLLW&unit=0&timeZone=0&format=text&Submit=Submit", URL, stationid, begin ,end);