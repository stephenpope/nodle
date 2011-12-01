using System;
using System.Net;
using RestSharp;

namespace Nodle.Distribution
{
    public class NodleConnection : INodleConnection
    {
        private readonly INodleDistributionConfig _config;
        private readonly INodleLogger _logger;

        internal RestClient Client { get; set; }

        public NodleConnection(INodleDistributionConfig config, INodleLogger logger = null)
        {
            if (config == null) throw new ArgumentNullException("config");

            _config = config;
            _logger = logger;

            Client = new RestClient(_config.BaseUrl);    
        }

        public void Send(INodleMessage message)
        {
            if (message == null) throw new ArgumentNullException("message");

            var request = new RestRequest("/pub/{channel}/", Method.POST);
            request.AddUrlSegment("channel", _config.Channel);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("nodleKey", _config.AccessKey);
            request.AddBody(message);
            Client.ExecuteAsync(request, LogResponse);  
        }

        private void LogResponse(RestResponse response)
        {
            if (_logger == null) return;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                _logger.Error("Message not sent ( + " + response.ErrorMessage + " )");
            }
        }
    }
}