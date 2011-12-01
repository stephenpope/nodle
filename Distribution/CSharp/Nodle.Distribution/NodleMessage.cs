using System;
using Newtonsoft.Json;

namespace Nodle.Distribution
{
    /// <summary>
    /// Simple implementation of a message
    /// </summary>
    public class NodleMessage: INodleMessage
    {
        /// <summary>
        /// The message body.  Contents will vary based on the object sent
        /// </summary>
        [JsonProperty("body")]
        public object Body { get; set; }
    }
}