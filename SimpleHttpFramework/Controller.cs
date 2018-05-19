using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpFramework
{
    public class Controller
    {
        public static HttpResponse Test(HttpRequest request)
        {
            return new HttpResponse(string.Format("rawData={0}\nmsg={1}", request.RawData, "test"));
        }
    }
}
