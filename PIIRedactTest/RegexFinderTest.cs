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
            var result = regexFinder.LocatePIIData(sensitiveInformation) as List<IPIIMatchResult>;
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].Start, 12);
            Assert.AreEqual(result[0].End, 19);
        }
    }
}
