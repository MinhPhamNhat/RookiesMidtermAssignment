using System.ComponentModel;
using System.Dynamic;
using System.Reflection;

namespace RookiesFashion.APIService.Helpers;

public static class Function
{

    public static string GetDescription(Enum en)
    {
        Type type = en.GetType();

        MemberInfo[] memInfo = type.GetMember(en.ToString());

        if (memInfo != null && memInfo.Length > 0)
        {
            object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attrs != null && attrs.Length > 0)
            {
                return ((DescriptionAttribute)attrs[0]).Description;
            }
        }

        return en.ToString();
    }
    public static bool DynamicHasProperty(dynamic item, string propertyName)
    {
        if (item is ExpandoObject eo)
        {
            return (eo as IDictionary<string, object>).ContainsKey(propertyName);
        }
        else
        {
            return item.GetType().GetProperty(propertyName);
        }
    }
}