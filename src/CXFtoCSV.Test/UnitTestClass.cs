using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CXFtoCSV;
using System.Text;

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

        [TestMethod]
        public void TestParseCXF()
        {
            string source1 = @"C:\Users\Amadeus\Downloads\CDM_12+4_Roli.cxf";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("index,L,a,b,ColorName");
            Helpers.ParseXml(source1, sb);
            var result = sb.ToString();
        }
    }
}
