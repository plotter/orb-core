using Newtonsoft.Json;
using System.Data;

namespace orb_core
{
    public class OrbCore
    {
        public static string toJson(DataSet dataSet) {
            return JsonConvert.SerializeObject(dataSet, Formatting.Indented);
        }
    }
}
