using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportGen.Model
{
    public class ReportData
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Issuer { get; set; }
        public string IssueYear { get; set; }
        public int BondStage { get; set; }
        public string BondType { get; set; }
        public decimal BondAmount { get; set; }
        public float BondMaxRate { get; set; }
        public float BondMinRate { get; set; }

        public int BuyFloorAmount { get; set; }
        public int BuyStepAmount { get; set; }
        public DateTime BondDeclareDate { get; set; }
        public DateTime BondIssueDate { get; set; }
    }
}
