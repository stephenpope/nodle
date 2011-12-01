using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Nodle.Distribution
{
    /// <summary>
    /// Inner model representation of config section
    /// </summary>
    public class NodleDistributionConfigSection : ConfigurationSection, INodleDistributionConfig
    {
        /// <summary>
        /// Gets the nodle service username.
        /// </summary>
        [ConfigurationProperty("accessKey", IsRequired = true)]
        public string AccessKey
        {
            get
            {
                return (string)this["accessKey"];
            }
        }

        /// <summary>
        /// Gets the nodle service URL.
        /// </summary>
        [ConfigurationProperty("baseUrl", IsRequired = true)]
        public string BaseUrl
        {
            get
            {
                return (string)this["baseUrl"];
            }
        }

        /// <summary>
        /// Gets the nodle service channel.
        /// </summary>
        [ConfigurationProperty("channel", IsRequired = true)]
        public string Channel
        {
            get { return (string)this["channel"]; }
        }
    }
}
