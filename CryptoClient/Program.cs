using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoClient
{
    internal class Program
    {
        private static Timer _timer = null;
        public static void Main(String[] args)
        {
            _timer = new Timer(TimerCallback, null, 0, 30000);// Her 30 Saniyede //
            Console.ReadLine();
        }

        private static void TimerCallback(Object o)
        {
            var cryptodata = CallAPIService.CallAPI("https://api.genelpara.com/embed/kripto.json", null, null, Method.Get);
            if (cryptodata != null) 
            {
                var result = DBAction.InsertDataToTable(cryptodata);
            }
        }
    }
}
