using System;
using System.Globalization;
using System.Net;
using System.Text;
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

            var machineId = string.Format("{0:X8}", System.Environment.MachineName.GetHashCode());

            var messageId = "nodle-" + machineId + "-" + new ShortGuid(Guid.NewGuid());

            var request = new RestRequest("/pub/{channel}/", Method.POST);
            request.AddUrlSegment("channel", _config.Channel);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("nodleKey", _config.AccessKey);
            request.AddHeader("nodleMachineId", machineId);
            request.AddHeader("nodleUserId", "Unknown");
            request.AddHeader("nodleMsgId", messageId);
            request.AddHeader("nodleMsgType", message.GetType().FullName);
            request.AddHeader("nodleTimestamp", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
            request.AddBody(message);
            //LogResponse(Client.Execute(request),messageId);
            //Client.Execute(request);
            Client.ExecuteAsync(request, (response) => LogResponse(response, messageId));  
        }

        private void LogResponse(RestResponse response, string messageId)
        {
            if (_logger == null) return;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                _logger.Error("Message failed ( " + response.StatusCode.ToString() + " )");
                return;
            }

            if (_logger.LogLevel == NodleLogLevel.INFO)
            {
                _logger.Info(string.Format("Message [{0}] sent! ({1})",messageId, response.Content));
            }
        }
    }
}