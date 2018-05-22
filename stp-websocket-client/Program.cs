using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading;
using WebSocket4Net;

namespace stp_websocket_client
{
    class Program
    {
        //Bu kod blogu ornek icin eklenmistir. Dogrudan uretim ortaminda kullanmayiniz.
        //This code is for demonstration purposes only. Do not use directly in production.
        readonly static string username = "YOUR_USERNAME";//uppercase
        readonly static string password = "YOUR_PASSWORD";
        readonly static string casurl = "https://testcas.epias.com.tr/cas/v1/tickets?format=text";
        readonly static string casservicename = "https://teststp.epias.com.tr";
        readonly static string cassturl = "https://testcas.epias.com.tr/cas/v1/tickets";
        readonly static string basepath = "http://teststp.epias.com.tr/stp-broadcaster-orchestrator/rest";
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            String tgt = getCasTGT();
            Console.WriteLine("TGT " + tgt);
            String st = getCasSt(tgt);
            Console.WriteLine("ST " + st);
            Configuration config = new Configuration();
            config.BasePath = basepath;


            //API Client can be generated via http://generator.swagger.io
            EndpointApi api = new EndpointApi(config);
       
            var headers = new List<Header>();
            headers.Add(new Header("transactionId", "Unique Identifier"));
            headers.Add(new Header("application", "Your Application Name"));
            EndpointGetRequest req = new EndpointGetRequest(headers, null);
            Console.WriteLine("Request -> " + req.ToJson());
            EndpointGetServiceResponse resp = api.Endpointget(st, req);

            String listenAddress = resp.Body.BroadcastAddress;

            Console.WriteLine("Response <- " + resp.ToJson());

            Console.WriteLine("listen <- " + listenAddress);

            WebSocket websocket = new WebSocket(listenAddress);

            websocket.MessageReceived += Websocket_MessageReceived;
            websocket.Opened += Websocket_Opened;
            websocket.Closed += Websocket_Closed;
            websocket.DataReceived += Websocket_DataReceived;
            websocket.Open();
            Console.ReadLine();
        }

        private static void Websocket_DataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine("Binary Data Received. ");
        }

        private static void Websocket_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("Socket Closed! Consider reconnection. ");
        }

        private static void Websocket_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("Socket opened! Initial checks. ");
        }

        private static void Websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            if ("X" == e.Message)
            {
                Console.WriteLine("HearthBeat received! Safe to ignore ");
            }
            else
            {
                Console.WriteLine("msg " + e.Message);
            }
        }




        private static List<Header> getHeaders()
        {
            List<Header> headers = new List<Header>();
            headers.Add(getApp());
            headers.Add(getTxId());
            return headers;
        }

        private static Header getTxId()
        {
            return new Header("transactionId", Guid.NewGuid().ToString());//if you want us to trace request, save this id.
        }

        private static Header getApp()
        {
            return new Header("application", "Your Application Name");
        }

        /**
         * get service ticket with given tgt. 
         */
        static string getCasSt(String tgt)
        {
            var request = (System.Net.HttpWebRequest)WebRequest.Create(cassturl + "/" + tgt);
            var postData = "service=" + casservicename;
            var data = Encoding.ASCII.GetBytes(postData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }

        /**
         * get tgt
         * 
         */
        static string getCasTGT()
        {
            var request = (HttpWebRequest)WebRequest.Create(casurl);
            var postData = "username=" + username;
            postData += "&password=" + password;
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }
    }
}
