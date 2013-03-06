using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportGen.Model;

namespace ReportGenTest
{
    public class TestBase
    {
        protected ReportData GetSampleData()
        {
            ReportData data = new ReportData
                                  {
                                      Name = "Sample1",
                                      Issuer = "王云鹏",
                                      IssueYear = "2013",
                                      BondAmount = 1229,
                                      BondDeclareDate = DateTime.Now,
                                      BondIssueDate = DateTime.Now.AddDays(3),
                                      BondMaxRate = 1.5f,
                                      BondMinRate = 2.5f,
                                      BondStage = 3,
                                      BondType = "国债",
                                      BuyFloorAmount = 1100,
                                      BuyStepAmount = 200
                                  };
            return data;
        }
    }
}
