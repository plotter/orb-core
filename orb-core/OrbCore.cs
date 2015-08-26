using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace orb_core
{
    public class OrbCore
    {
        public static string toJson(DataSet dataSet) {
            return JsonConvert.SerializeObject(dataSet, Formatting.Indented);
        }

        public static void createTable(DataSet dataSet, OrbDbConn dbConn, OrbTableAdapter tableAdapter)
        {
            SqlConnection sqlConn = new SqlConnection(dbConn.ConnectionString);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(tableAdapter.SelectSql, sqlConn);
            sqlAdapter.Fill(dataSet, tableAdapter.TableName);
        }

        public DataSet DataSet { get; set; }
        public OrbCore createDataSet(string dataSetName)
        {
            DataSet = new DataSet(dataSetName);
            return this;
        }

        public OrbCore createTable(OrbDbConn conn, OrbTableAdapter adapter)
        {
            createTable(DataSet, conn, adapter);
            return this;
        }

        public string toJson()
        {
            return toJson(DataSet);
        }
    }
}
