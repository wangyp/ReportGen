using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportGen.Model;

namespace ReportGen.Dal
{
    public interface IDataFieldRepository
    {
        ReportData GetByName(string name);
        IList<ReportData> GetAll();
        void Save(ReportData reportData);
        void Update(ReportData reportData);
        void Delete(string name);
    }
}
