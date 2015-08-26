using Newtonsoft.Json;
using System.Data;

namespace orb_core
{
    class OrbCore
    {
        string toJson(DataSet dataSet) {
            return JsonConvert.SerializeObject(dataSet, Formatting.Indented);
        }
    }
}
