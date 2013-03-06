using System.Diagnostics;
using System.Collections.Generic;
using NUnit.Framework;
using ReportGen.Dal;
using ReportGen.Model;

namespace ReportGenTest
{
    [TestFixture]
    public class DalTest
    {
        public IDataFieldRepository DataFieldRepository { get; set; }


        [TestFixtureSetUp]
        public void init()
        {
            DataFieldRepository = new DataFieldRepository();
        }

        [Test]
        public void TestSave()
        {
            ReportData data = new ReportData
                                  {
                                      Id = 0,
                                      Name = "Data"
                                  };
            DataFieldRepository.Save(data);

            IList<ReportData> datas = DataFieldRepository.GetAll();
            Assert.IsTrue(datas.Count > 0);
            foreach (var dbData in datas)
            {
                Debug.WriteLine(dbData.Name);
            }

            var model = DataFieldRepository.GetByName("Data");
            Assert.IsNotNull(model);
        }


        [Test]
        public void TestDelete()
        {
            DataFieldRepository.Delete("Data");
            IList<ReportData> datas = DataFieldRepository.GetAll();
            Assert.IsTrue(datas.Count > 0);
            foreach (var dbData in datas)
            {
                Debug.WriteLine(dbData.Name);
            }
        }
    }
}
