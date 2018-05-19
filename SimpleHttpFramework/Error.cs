using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpFramework
{
    public class Error
    {
        public static ErrorResponse UrlNotFound()
        {
            return new ErrorResponse("UrlNotFound");
        } 
    }
}
