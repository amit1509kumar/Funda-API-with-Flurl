using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TopAmsMakelaars.CoreLogic;
using System.Linq;
using System.Collections.Generic;
using TopAmsMakelaars.Models;


namespace TopAmsMakelaars.Test
{
    [TestClass]
    public class BoundaryTests
    {
        [TestMethod]
        public void CheckForNullValue()
        {
            var logic1 = new TopMakelaars();   
            Assert.AreEqual(logic1.GetTopTen(null).Count(),0);
            
            var logic2 = new TopMakelaarsOptimize();
            Assert.AreEqual(logic2.GetTopTen(null).Count(), 0);
        }

        [TestMethod]
        public void CheckForEmptyRecords()
        {
            var logic1 = new TopMakelaars();
            Assert.AreEqual(logic1.GetTopTen(new List<Makelaar>()).Count(), 0);

            var logic2 = new TopMakelaarsOptimize();
            Assert.AreEqual(logic2.GetTopTen(new List<Makelaar>()).Count(), 0);
        }

        [TestMethod]
        public void CheckForLessThanTenRecords()
        {
            var testData = new TestData();

            var logic1 = new TopMakelaars();
            Assert.IsTrue(logic1.GetTopTen(testData.GetTestData(5)).Count() <= 5);

            var logic2 = new TopMakelaarsOptimize();
            Assert.IsTrue(logic2.GetTopTen(testData.GetTestData(5)).Count() <= 5);
        }
    }
}
