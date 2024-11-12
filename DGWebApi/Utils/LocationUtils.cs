using System.Globalization;

namespace DGWebApi.Utils
{
    public class LocationUtils
    {
        public static string GetNameFromCountryCode(string code)
        {
            try
            {
                var regionInfo = new RegionInfo(code);
                return regionInfo.EnglishName;
            }
            catch
            {
                return "country code not found";
            }
        }
    }
}
