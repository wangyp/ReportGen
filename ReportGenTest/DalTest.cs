using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportGen.Dal;
using ReportGen.Model;

namespace ReportGenTest
{
    [TestClass]
    public class ServiceTest
    {
        public IDataFieldRepository DataFieldRepository { get; set; }


        [TestInitialize]
        public void init()
        {
            DataFieldRepository = new DataFieldRepository();
        }

        [TestMethod]
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


        [TestMethod]
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
