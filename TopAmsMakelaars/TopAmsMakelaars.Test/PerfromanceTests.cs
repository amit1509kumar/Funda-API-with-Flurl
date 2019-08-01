using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TopAmsMakelaars.CoreLogic;
using System.Diagnostics;

namespace TopAmsMakelaars.Test
{
    /// <summary>
    /// checking performance of both the logics on large data sets
    /// test limit set to 1 sec
    /// </summary>
    [TestClass]
    public class PerformanceTest
    {

        int m_executionTimeLimitinMilliseconds = 1000;
        /// <summary>
        /// testing data size 10^3
        /// </summary>
        [TestMethod]
        public void PerformanceTest10Power3()
        {

            var testData = new TestData();
            var data = testData.GetTestData((int)Math.Pow(10, 3));

            var stopwatch = new Stopwatch();

            // Begin timing
            stopwatch.Start();

            var logic = new TopMakelaars();
            var ans = logic.GetTopTen(data);

            stopwatch.Stop();

            Assert.IsTrue(stopwatch.ElapsedMilliseconds < m_executionTimeLimitinMilliseconds);
        }

        /// <summary>
        /// test data size 10^6
        /// </summary>
        [TestMethod]
        public void PerformanceTest10Power6()
        {
            var testData = new TestData();
            var data = testData.GetTestData((int)Math.Pow(10, 6));

            var stopwatch = new Stopwatch();

            // Begin timing
            stopwatch.Start();

            var logic = new TopMakelaars();
            var ans = logic.GetTopTen(data);

            stopwatch.Stop();

            Assert.IsTrue(stopwatch.ElapsedMilliseconds <= m_executionTimeLimitinMilliseconds);
        }    


        /// <summary>
        /// optimize method with 10^3 records
        /// </summary>
        [TestMethod]
        public void PerformanceTest10Power3_Optimize()
        {
            var testData = new TestData();
            var data = testData.GetTestData((int)Math.Pow(10, 3));

            var stopwatch = new Stopwatch();

            // Begin timing
            stopwatch.Start();

            var logic = new TopMakelaarsOptimize();
            var ans = logic.GetTopTen(data);

            stopwatch.Stop();

            Assert.IsTrue(stopwatch.ElapsedMilliseconds <= m_executionTimeLimitinMilliseconds);
        }

        /// <summary>
        /// test data size 10^6
        /// </summary>
        [TestMethod]
        public void PerformanceTest10Power6_Optimize()
        {
            var testData = new TestData();
            var data = testData.GetTestData((int)Math.Pow(10, 6));

            var stopwatch = new Stopwatch();

            // Begin timing
            stopwatch.Start();

            var logic = new TopMakelaarsOptimize();
            var ans = logic.GetTopTen(data);

            stopwatch.Stop();

            Assert.IsTrue(stopwatch.ElapsedMilliseconds <= m_executionTimeLimitinMilliseconds);
        }

    


    }
}
