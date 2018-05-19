using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpFramework
{
    public class ErrorResponse:HttpResponse
    {
        public ErrorResponse() { }
        public ErrorResponse(string msg)
        {
            this.Data = msg;
        }
    }
}
