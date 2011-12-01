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
        private NodleDistributionConfig _config;

        [SetUp]
        public void Setup()
        {
            _config = ConfigurationManager.GetSection("nodleDistribution") as NodleDistributionConfig;
        }

        [TearDown]
        public void TearDown()
        {
            _config = null;
        }

        [Test]
        public void Get_Username_ReturnsGivenValue()
        {
            Assert.AreEqual("ConfigUsername", _config.Username);
        }

        [Test]
        public void Get_Password_ReturnsGivenValue()
        {
            Assert.AreEqual("ConfigPassword", _config.Password);
        }

        [Test]
        public void Get_Url_ReturnsGivenValue()
        {
            Assert.AreEqual("http://ConfigUrl", _config.Url);
        }

        [Test]
        public void Get_Channel_ReturnsGivenValue()
        {
            Assert.AreEqual("ConfigChannel", _config.Channel);
        }
    }
}
