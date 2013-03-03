using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using ReportGen.Model;

namespace ReportGen.Dal
{
    public class DataFieldRepository : IDataFieldRepository
    {
        private SQLiteConnection _connection = null;
        private string _connectString = null;

        private const string GET_ALL_SQL = "select * from main";
        private const string GETBYNAME_SQL = "select * from main where Name=@Name";
        private const string INSERT_SQL = "INSERT INTO main(Name) values(@Name)"; 
        private const string UPDATE_SQL = "update main set value=@Value where Name=@Name"; 
        private const string DELETE_SQL = "delete from main where Name=@Name"; 



        public ReportData GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ApplicationException("ReportData.Name cannot be null");
            }
            var reader = SqLiteDbHelper.Instance.ExecuteReader(GETBYNAME_SQL, new[]
                                        {
                                            new SQLiteParameter("@Name",name), 
                                        });
            
            try
            {
                if (!reader.HasRows)
                {
                    throw new ApplicationException("Not fount data with Name: " + name);
                }
                    reader.Read();
                    return GetCurrentModel(reader);
            }
            finally
            {
                    reader.Close();
            }
        }

        public IList<ReportData> GetAll()
        {
            var all = new List<ReportData>();
            var reader = SqLiteDbHelper.Instance.ExecuteReader(GET_ALL_SQL, null);
            while (reader.Read())
            {
                var model = GetCurrentModel(reader);
                all.Add(model);
            }
            reader.Close();
            return all;
        }

        public void Save(ReportData reportData)
        {
            SQLiteParameter[] parameters = ModelToParameters(reportData);
            SqLiteDbHelper.Instance.ExecuteNonQuery(INSERT_SQL, parameters);
        }

        public void Update(ReportData reportData)
        {
            if (reportData == null)
            {
                throw new NullReferenceException("reportData is null ");
            }
            SQLiteParameter[] parameters = ModelToParameters(reportData);
            SqLiteDbHelper.Instance.ExecuteNonQuery(UPDATE_SQL, parameters.ToArray());
        }

        public void Delete(string name)
        {
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            parameters.Add(new SQLiteParameter("@Name", name));
            SqLiteDbHelper.Instance.ExecuteNonQuery(DELETE_SQL, parameters.ToArray());
        }


        private ReportData GetCurrentModel(IDataReader reader)
        {
            ReportData model = new ReportData();
            model.Name = reader.GetString(1);
            return model;
        }

        private SQLiteParameter[] ModelToParameters(ReportData reportData)
        {
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();
            if (reportData.Id != 0)
            {
                parameters.Add(new SQLiteParameter("@Id", reportData.Id));
            }
            parameters.Add(new SQLiteParameter("@Name", reportData.Name));
            return parameters.ToArray();
        }
    }
}
