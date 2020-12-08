using System;

namespace Steunijos.Web.SteunijosServices
{
    public static class EnumValueToStringConverter
    {
        public static string ConvertToString<T>(this T @enum) where T : System.Enum
        {
            //take the enum value and change
            var candidateString = @enum.ToString().Replace("_", " ");
            return candidateString;
        }
    }
}