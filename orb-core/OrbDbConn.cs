namespace orb_core
{
    public class OrbDbConn
    {
        public string ConnectionString { get; set; }
        public OrbDbConn connectionString(string s)
        {
            ConnectionString = s;
            return this;
        }
    }
}
