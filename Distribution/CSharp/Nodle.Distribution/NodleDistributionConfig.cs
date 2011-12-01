using System.Configuration;

namespace Nodle.Distribution
{
    /// <summary>
    /// General confgiration object
    /// </summary>
    public class NodleDistributionConfig : ConfigurationSection
    {
        /// <summary>
        /// Gets the nodle service username.
        /// </summary>
        [ConfigurationProperty("accesskey", IsRequired = true)]
        public string AccessKey
        {
            get
            {
                return (string)this["accesskey"];
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

        //internal NodleDistributionConfig(string username, string password, string url, string channel)
        //{
        //    this["username"] = username;
        //    this["password"] = password;
        //    this["url"] = url;
        //    this["channel"] = channel;
        //}
    }
}