using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CXFtoCSV;

namespace CXFtoCSV.Test
{
    [TestClass]
    public class UnitTestClass
    {
        [TestMethod]
        public void TestPathCreation()
        {
            string source1 = @"C:\Users\Amadeus\Downloads\CDM_12+4_Roli.cxf";
            string target1 = Helpers.GetTargetPath(source1);

            Assert.AreEqual(@"C:\Users\Amadeus\Downloads\CDM_12+4_Roli.csv", target1);
        }
    }
}
