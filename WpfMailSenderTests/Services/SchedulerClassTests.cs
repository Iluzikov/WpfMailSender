using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfMailSender.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender.Services.Tests
{
    [TestClass()]
    public class SchedulerClassTests
    {
        SchedulerClass sc;
        TimeSpan ts;

        [TestInitialize]
        public void TestInitialize()
        {
            sc = new SchedulerClass();
            ts = new TimeSpan();
        }

        [TestMethod()]
        public void GetSendTime_empty_ts()
        {
            string strTimeTest = "";
            TimeSpan tsTest = sc.GetSendTime(strTimeTest);
            Assert.AreEqual(ts, tsTest);
        }

        [TestMethod()]
        public void GetSendTime_sdf_ts()
        {
            string strTimeTest = "sdf";
            TimeSpan tsTest = sc.GetSendTime(strTimeTest);
            Assert.AreEqual(ts, tsTest);
        }

        [TestMethod()]
        public void GetSendTime_correctTime_Equal()
        {
            string strTimeTest = "12:12";
            TimeSpan tsCorrect = new TimeSpan(12, 12, 0);
            TimeSpan tsTest = sc.GetSendTime(strTimeTest);
            Assert.AreEqual(tsCorrect, tsTest);
        }

        [TestMethod()]
        public void GetSendTime_inCorrectHour_ts()
        {
            string strTimeTest = "25:12";
            TimeSpan tsTest = sc.GetSendTime(strTimeTest);
            Assert.AreEqual(ts, tsTest);
        }

        [TestMethod()]
        public void GetSendTime_inCorrectMin_ts()
        {
            string strTimeTest = "12:65";
            TimeSpan tsTest = sc.GetSendTime(strTimeTest);
            Assert.AreEqual(ts, tsTest);
        }
    }
}