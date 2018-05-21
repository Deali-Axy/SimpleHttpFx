using System;
namespace SimpleHttpFramework.Http.Response {
	public class HttpResponseError : HttpResponseBase {
		public HttpResponseError ()
		{
			this.StatusCode = 400;
			this.Content = "Bad Request";
		}

		public HttpResponseError (int code, string phrase)
		{
			this.StatusCode = code;
			this.Content = phrase;
		}
	}
}
