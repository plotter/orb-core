using System.Data.SqlClient;

namespace orb_core
{
    public class OrbTableAdapter
    {
        public string SelectSql { get; set; }
        public string TableName { get; set; }

        public OrbTableAdapter selectSql(string s)
        {
            SelectSql = s;
            return this;
        }

        public OrbTableAdapter tableName(string name)
        {
            TableName = name;
            return this;
        }
    }
}
