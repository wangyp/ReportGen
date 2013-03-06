<<<<<<< HEAD
﻿using NUnit.Framework;
using ReportGen.Model;
using ReportGen.Service;
using WordDocumentGenerator.Library;

namespace ReportGenTest
{
    [TestFixture]
    public class ServiceTest : TestBase
    {
        private WordGenerateService service;

        [TestFixtureSetUp]
        public void SetUp()
        {
            service = new WordGenerateService();
        }

        [Test]
        public void DocGenerateTest()
        {
            ReportData data = GetSampleData();
            WordGenerateService.Generate(WordGenerateService.SUBSCRIBESUMMARY, data, "test.docx");
=======
﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReportGenTest
{
    [TestClass]
    public class DalTest
    {
        [TestMethod]
        public void TestMethod1()
        {
>>>>>>> ab03f3c3b1226efe92881b9796b7a200d6bde720
        }
    }
}
