using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIIRedact;
using System.Collections.Generic;

namespace PIIRedactTest
{
    [TestClass]
    public class RegexFinderTest
    {
        [TestMethod]
        public void LocatePIIData_Email()
        {
            var sensitiveInformation = "My email is x@y.com";
            var regexFinder = new RegexFinder(RegexLibrary.Email);
            var result = regexFinder.LocatePIIData(sensitiveInformation) as List<IPatternMatchResult>;
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(12, result[0].Start);
            Assert.AreEqual(19, result[0].End);
        }

        [TestMethod]
        public void LocatePIIData_PhoneNo()
        {
            var sensitiveInformation = "My phone no is 1234567890";
            var regexFinder = new RegexFinder(RegexLibrary.USPhoneNumber);
            var result = regexFinder.LocatePIIData(sensitiveInformation) as List<IPatternMatchResult>;
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(15, result[0].Start);
            Assert.AreEqual(25, result[0].End);
        }

        [TestMethod]
        public void LocatePIIData_IPAddress()
        {
            var sensitiveInformation = "My ip address is 127.0.0.1";
            var regexFinder = new RegexFinder(RegexLibrary.IPAddress);
            var result = regexFinder.LocatePIIData(sensitiveInformation) as List<IPatternMatchResult>;
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(sensitiveInformation.IndexOf("127"), result[0].Start);
            Assert.AreEqual(sensitiveInformation.IndexOf(".1") + 2, result[0].End);
        }
    }
}
