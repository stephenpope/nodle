using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Nodle.Distribution.Tests
{
    [TestFixture]
    public class NodleDistributionConfigFixture
    {
        private NodleDistributionConfig _config;
        private string _username = "TestyMcTesterson";
        private string _password = "MyPasswordIsRubbish";
        private string _url = "http://nodletestaddress";
        private string _channel = "TheWorld";

        [SetUp]
        public void Setup()
        {
            _config = new NodleDistributionConfig(_username, _password, _url, _channel);
        }

        [TearDown]
        public void TearDown()
        {
            _config = null;
        }

        [Test]
        public void Get_Username_ReturnsGivenValue()
        {
            Assert.AreEqual(_username, _config.Username);
        }

        [Test]
        public void Get_Password_ReturnsGivenValue()
        {
            Assert.AreEqual(_password, _config.Password);
        }

        [Test]
        public void Get_Url_ReturnsGivenValue()
        {
            Assert.AreEqual(_url, _config.Url);
        }

        [Test]
        public void Get_Channel_ReturnsGivenValue()
        {
            Assert.AreEqual(_channel, _config.Channel);
        }
    }
}
