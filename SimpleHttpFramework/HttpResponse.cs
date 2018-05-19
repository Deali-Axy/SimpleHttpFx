using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpFramework
{
    public class HttpResponse
    {
        public string Data;
        public HttpResponse()
        {

        }

        public HttpResponse(string data)
        {
            this.Data = data;
        }
    }
}
