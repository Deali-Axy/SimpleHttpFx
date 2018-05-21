using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleHttpFramework.Http.Response;
using SimpleHttpFramework.Http.Request;

namespace SimpleHttpFramework {
	public class Controller {
		public delegate HttpResponseBase ControllerMethod (HttpRequest request);

		public static HttpResponse Test (HttpRequest request)
		{
			return new HttpResponse (string.Format ("rawData={0}\nmsg={1}", request.Body, "test"));
		}

		public static HttpResponse Hello (HttpRequest request)
		{
			return new HttpResponse ("hello");
		}
	}
}
