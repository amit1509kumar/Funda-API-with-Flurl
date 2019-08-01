using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TopAmsMakelaars.CoreLogic;
using System.Linq;

namespace TopAmsMakelaars.Test
{
    [TestClass]
    public class CoreLogicTests
    {
       [TestMethod]
       public void CheckForDataMismatch()
        {
            var logic1 = new TopMakelaars();          
            var logic2 = new TopMakelaarsOptimize();
            var testData = new TestData();

            var data = testData.GetTestData(100);

            var records1 = logic1.GetTopTen(data).ToList();
            var records2 = logic1.GetTopTen(data).ToList();

            Assert.IsTrue(records1.Count == records2.Count);           
            Assert.IsTrue(records1.Count > 0 && records1.Count <= 10);
            Assert.IsTrue(records2.Count > 0 && records2.Count <= 10);


            for(int i = 0; i < records1.Count; i++)
            {
                Assert.AreEqual(records1[i].Id, records2[i].Id);
                Assert.AreEqual(records1[i].Name, records2[i].Name);
            }


        }
    }
}
