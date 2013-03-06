using NUnit.Framework;
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
        }
    }
}
