using System.Text.RegularExpressions;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    public static class Validator
    {

        public static bool ValidateUrl(string url)
        {
            string regex = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            return Regex.IsMatch(url, regex);
        }

        public static bool ValidateCategory(string categoryName)
        {
            string regex = @"^[A-Öa-ö0-9_\/]{3,20}$";
            return Regex.IsMatch(categoryName, regex);
        }
    }
}
