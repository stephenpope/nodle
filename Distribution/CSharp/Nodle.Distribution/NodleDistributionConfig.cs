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
        [ConfigurationProperty("username", IsRequired = true)]
        public string Username
        {
            get
            {
                return (string)this["username"];
            }
        }

        /// <summary>
        /// Gets the nodle service password.
        /// </summary>
        [ConfigurationProperty("password", IsRequired = true)]
        public string Password
        {
            get
            {
                return (string)this["password"];
            }
        }

        /// <summary>
        /// Gets the nodle service URL.
        /// </summary>
        [ConfigurationProperty("url", IsRequired = true)]
        public string Url
        {
            get
            {
                return (string)this["url"];
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
    }
}