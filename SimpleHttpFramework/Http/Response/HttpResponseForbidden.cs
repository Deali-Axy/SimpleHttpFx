using System;
namespace SimpleHttpFramework.Http.Response {
	public class HttpResponseForbidden : HttpResponseError {
		public HttpResponseForbidden ()
		{
			this.StatusCode = 403;
			this.Content = "Not Allowed.";
		}
	}
}
