using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpFramework
{
    public class HttpRequest
    {
        public string Method;
        public string RawData;

        public HttpRequest() { }
        public HttpRequest(string method,string rawdata)
        {
            this.Method = method;
            this.RawData = rawdata;
        }
    }
}
