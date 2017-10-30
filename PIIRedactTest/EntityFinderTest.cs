using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIIRedact;
using System.Collections.Generic;

namespace PIIRedactTest
{
    [TestClass]
    public class EntityFinderTest
    {
        [TestMethod]
        public void LocatePIIData_Name()
        {
            var sensitiveInformation = "I am John Doe";
            var entityFinder = new EntityFinder();
            var result = entityFinder.LocatePIIData(sensitiveInformation) as List<IPatternMatchResult>;
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(5, result[0].Start);
            Assert.AreEqual(13, result[0].End);
        }

        [TestMethod]
        public void LocatePIIData_Location()
        {
            var sensitiveInformation = "I live in London";
            var entityFinder = new EntityFinder();
            var result = entityFinder.LocatePIIData(sensitiveInformation) as List<IPatternMatchResult>;
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(10, result[0].Start);
            Assert.AreEqual(16, result[0].End);
        }

        [TestMethod]
        public void LocatePIIData_Organization()
        {
            var sensitiveInformation = "I work for Stanford";
            var entityFinder = new EntityFinder();
            var result = entityFinder.LocatePIIData(sensitiveInformation) as List<IPatternMatchResult>;
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(11, result[0].Start);
            Assert.AreEqual(19, result[0].End);
        }
    }
}
