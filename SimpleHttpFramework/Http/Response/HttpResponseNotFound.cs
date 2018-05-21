using System;
namespace SimpleHttpFramework.Http.Response {
	public class HttpResponseNotFound : HttpResponseError {
		public HttpResponseNotFound ()
		{
			this.StatusCode = 404;
			this.Content = "Not Found!";
		}
	}
}
