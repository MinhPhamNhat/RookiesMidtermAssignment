using System.Collections.Generic;
using System.Text.Json;

namespace RookiesFashion.SharedRepo.Helpers;

public static class MyResponseMapper
{
    public static List<Dictionary<string, object>> MapperToDictList(JsonElement jsonEl)
    {
        return jsonEl.Deserialize<List<Dictionary<string, object>>>();
    }
    public static Dictionary<string, object> MapperToDict(JsonElement jsonEl)
    {
        return jsonEl.Deserialize<Dictionary<string, object>>();
    }
    public static List<T> MapJsonToList<T>(JsonElement jsonEl)
    {
        return jsonEl.Deserialize<List<T>>();
    }
    public static T MapJson<T>(JsonElement jsonEl)
    {
        return jsonEl.Deserialize<T>();
    }
    public static object MapFromJsonElement<T>(JsonElement jsonEl)
    {
        if (jsonEl.GetArrayLength() > 0)
        {
            List<T> l = new List<T>();
            var objList = jsonEl.Deserialize<List<object>>();
            l = objList.Select(i => Map<T>(i)).ToList();
            return l;
        }
        return jsonEl.Deserialize<T>();
    }

    public static T Map<T>(object Obj)
    {
        return (T)Convert.ChangeType(Obj, typeof(T));
    }
}