using System;
using Newtonsoft.Json;

namespace Nodle.Distribution
{
    /// <summary>
    /// Message interface
    /// </summary>
    public interface INodleMessage
    {
        [JsonProperty("created")]
        DateTime Created { get; }

        [JsonProperty("body")]
        object Body { get; set; }
    }
}