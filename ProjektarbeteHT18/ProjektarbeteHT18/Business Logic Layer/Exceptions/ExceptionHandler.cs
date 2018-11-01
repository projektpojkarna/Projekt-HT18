using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeteHT18.Business_Logic_Layer.Exceptions
{

    public class ExceptionHandler
    {
        public delegate void Handler(string msg);
        public event Handler OnException;

        public void HandleException(Exception e)
        {
            OnException("Något gick fel vid inläsning av RSS-feed.");
        }
    }

    public class URLException : Exception
    {
        public URLException() : base("Felaktigt URL") { }
        public URLException(string message) : base(message) { }
        public URLException(string message, Exception inner) : base(message, inner) { }

    }

    public class CategoryException : Exception
    {
        public CategoryException() : base("En eller flera pods använder kategorin.") { }
        public CategoryException(string message) : base(message) { }
        public CategoryException(string message, Exception inner) : base(message, inner) { }
    }
}
