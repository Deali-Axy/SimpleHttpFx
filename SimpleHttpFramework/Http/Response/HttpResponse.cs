using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpFramework.Http.Response {
	public class HttpResponse : HttpResponseBase {
		public HttpResponse () { }
		public HttpResponse (string content)
		{
			this.Content = content;
		}
	}
}