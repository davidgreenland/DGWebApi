using System.Globalization;

namespace DGWebApi.Utils
{
    public class LocationUtils
    {
        public static string GetNameFromCountryCode(string code)
        {
            var cultureInfo = new CultureInfo(code);
            var ri = new RegionInfo(cultureInfo.Name);
            return ri.EnglishName;
        }
    }
}
