using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpFramework.Http.Response {
	public class HttpResponseServerError : HttpResponseBase {
		public HttpResponseServerError ()
		{
			this.StatusCode = 500;
		}
		public HttpResponseServerError (string msg) : this ()
		{
			this.Content = msg;
		}
	}
}
