using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportGen.Service;
using WordDocumentGenerator.Library;

namespace ReportGenTest
{
    [TestClass]
    public class DalTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            DocumentGenerationInfo info;
            var generator = new WordReportGenerator(info);
        }
    }
}
