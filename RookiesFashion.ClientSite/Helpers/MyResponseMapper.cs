using System.Text.Json;
using RookiesFashion.ClientSite.Models;

namespace RookiesFashion.ClientSite.Helpers;

public static class MyResponseMapper
{
    public static object MapFromJsonElement(JsonElement jsonEl)
    {
        return jsonEl.GetArrayLength() > 0 ? jsonEl.Deserialize<List<object>>() : jsonEl.Deserialize<object>();
    }

    public static T Map<T>(object Obj)
    {
        return (T)Convert.ChangeType(Obj, typeof(T));
    }

    public static Product MapProduct(object Obj)
    {
        return (Product)Obj;
    }
}