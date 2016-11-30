using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyNewService;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
           Assert.AreEqual(false, GestionDate.dansLintervalleCL());
            Assert.AreEqual(true, GestionDate.dansLintervalleRB());
            
        }
    }
}
