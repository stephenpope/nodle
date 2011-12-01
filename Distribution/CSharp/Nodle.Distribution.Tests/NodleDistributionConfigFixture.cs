using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Nodle.Distribution.Tests
{
    [TestFixture]
    public class NodleDistributionConfigFixture
    {

        [Test]
        public void Get_Instance_ReturnsInstance()
        {
            var config = NodleDistributionConfig.Instance;
            Assert.IsInstanceOf<NodleDistributionConfig>(config);
        }

        [Test]
        public void Get_AccessKey_ReturnsGivenValue()
        {
            var config = NodleDistributionConfig.Instance;
            Assert.AreEqual("ConfigAccessKey", config.AccessKey);
        }

        [Test]
        public void Get_BaseUrl_ReturnsGivenValue()
        {
            var config = NodleDistributionConfig.Instance;
            Assert.AreEqual("http://ConfigUrl", config.BaseUrl);
        }

        [Test]
        public void Get_Channel_ReturnsGivenValue()
        {
            var config = NodleDistributionConfig.Instance;
            Assert.AreEqual("ConfigChannel", config.Channel);
        }

        [Test]
        public void Get_InstanceWithMissingAccessKey_ReturnsMissingParameterError()
        {
            NodleDistributionConfig._customSection = "nodleDistributionMissingAccessKey";
            Assert.Throws<ConfigurationErrorsException>(() =>
                                                            {
                                                                var dumb = NodleDistributionConfig.Instance;
                                                            });
        }
        [Test]
        public void Get_InstanceWithMissingBaseUrl_ReturnsMissingParameterError()
        {
            NodleDistributionConfig._customSection = "nodleDistributionMissingBaseUrl";
            Assert.Throws<ConfigurationErrorsException>(() =>
                                                            {
                                                                var dumb = NodleDistributionConfig.Instance;
                                                            });
        }[Test]
        public void Get_InstanceWithMissingChannel_ReturnsMissingParameterError()
        {
            NodleDistributionConfig._customSection = "nodleDistributionChannel";
            Assert.Throws<ConfigurationErrorsException>(() =>
                                                            {
                                                                var dumb = NodleDistributionConfig.Instance;
                                                            });
        }
    }
}
