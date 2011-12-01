using System.Configuration;

namespace Nodle.Distribution
{
    /// <summary>
    /// General confgiration object
    /// </summary>
    public class NodleDistributionConfig
    {
        private static INodleDistributionConfig _instance;
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
    }
}
