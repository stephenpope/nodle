using System;
using RestSharp;

namespace Nodle.Distribution
{
    public class NodleConnection : INodleConnection
    {
        public string BaseUrl { get; set; }

        internal RestClient Client { get; set; }

        public NodleConnection(string baseUrl)
        {
            Client = new RestClient(baseUrl);    
        }

        public NodleConnection(Uri baseUrl)
        {
            Client = new RestClient(baseUrl.ToString());    
        }

        public void Send(INodelMessage message)
        {
            throw new System.NotImplementedException();
        }
    }
}