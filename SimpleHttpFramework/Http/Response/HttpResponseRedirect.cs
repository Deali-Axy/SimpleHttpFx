using System;
namespace SimpleHttpFramework.Http.Response {
	public class HttpResponseRedirect : HttpResponse {
		public HttpResponseRedirect ()
		{
			this.StatusCode = 300;
		}
	}
}
