using System.Configuration;

namespace Nodle.Distribution
{
    /// <summary>
    /// General confgiration object
    /// </summary>
    public class NodleDistributionConfig : ConfigurationSection, INodleDistributionConfig
    {
        private static NodleDistributionConfig _instance;
        private static readonly string _defaultSection = "nodleDistribution";
        internal static string _customSection { get; set; }

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
            get { return (string) this["channel"]; }
        }

        /// <summary>
        /// Returns the config instance.
        /// </summary>
        public static NodleDistributionConfig Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = ConfigurationManager.GetSection(_customSection ?? _defaultSection ) as NodleDistributionConfig;
                }

                return _instance;
            }
        }
    }
}
