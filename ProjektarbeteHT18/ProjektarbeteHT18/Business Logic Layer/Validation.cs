using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    class Validation {

        public static void UrlValidation(string url)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                && uriResult.Scheme == Uri.UriSchemeHttp;
           if(result == false)
            {
               
            }
        }

        public bool IsLetters(string input)
        {
            bool result = Regex.IsMatch(input, "^[a-öA-Ö]+$");
            return result;
        }
    }
}
