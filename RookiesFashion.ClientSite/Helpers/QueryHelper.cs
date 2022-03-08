using System.Text;
using Newtonsoft.Json;

public static class QueryHelper
{
    public static string parseQuery(string url, object model)
    {
        var serialized = JsonConvert.SerializeObject(model);
        var deserialized = JsonConvert.DeserializeObject<Dictionary<string, string>>(serialized);
        var result = deserialized.Where(kvp => kvp.Value!=null).Select((kvp) => (kvp.Key.ToString() + "=" + Uri.EscapeDataString(kvp.Value))).Aggregate((p1, p2) => p1 + "&" + p2);
        return url+"?"+result;
    }
}