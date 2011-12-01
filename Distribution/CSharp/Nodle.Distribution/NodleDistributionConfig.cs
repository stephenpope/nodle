using System.Configuration;

namespace Nodle.Distribution
{
    /// <summary>
    /// General confgiration object
    /// </summary>
    public class NodleDistributionConfig
    {
        private static NodleDistributionConfigSection _instance;
        private static readonly string _defaultSection = "nodleDistribution";
        internal static string _customSection { get; set; }
        
        /// <summary>
        /// Returns the config instance.
        /// </summary>
        public static INodleDistributionConfig Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = ConfigurationManager.GetSection(_customSection ?? _defaultSection) as NodleDistributionConfigSection;
                }

                return _instance;
            }
        }

        /// <summary>
        /// Inner model representation of config section
        /// </summary>
        private class NodleDistributionConfigSection : ConfigurationSection, INodleDistributionConfig
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
}
