using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIIRedact;

namespace PIIRedactTest
{
    [TestClass]
    public class PIIRedactorTest
    {
        private PIIRedactor pIIRedactor; 
        public PIIRedactorTest()
        {
            this.pIIRedactor = new PIIRedactor();
        }

        [TestMethod]
        public void GetRedactData_BasicTest()
        {
            var sensitiveData = "My name is Robert. I live in London. My phone number is 123456789. My email is robert@dontexist.com. I want to download office 2016";
            var expected = "My name is xxxxxx. I live in xxxxxx. My phone number is xxxxxxxxx. My email is xxxxxx@xxxxxxxxx.xxx. I want to download office xxxx";
            var actual = this.pIIRedactor.GetRedactedData(sensitiveData);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddToWhiteList_WhitelistOffice()
        {
            var sensitiveData = "My name is Robert. I live in London. My phone number is 123456789. My email is robert@dontexist.com. I want to download office 2016";
            this.pIIRedactor.AddToWhiteList(new RegexGroupFinder(@"(office)\s+(\d{4})"));
            var expected = "My name is xxxxxx. I live in xxxxxx. My phone number is xxxxxxxxx. My email is xxxxxx@xxxxxxxxx.xxx. I want to download office 2016";

            var actual = this.pIIRedactor.GetRedactedData(sensitiveData);
            Assert.AreEqual(expected, actual);
        }

    }
}
