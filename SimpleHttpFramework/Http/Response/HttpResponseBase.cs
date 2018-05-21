using System;
using System.Net;
using System.Text;

namespace SimpleHttpFramework.Http.Response {
	public abstract class HttpResponseBase {
		public int StatusCode = 200;
		public HttpResponseHeader Header;
		public CookieCollection Cookies;
		public string ContentType;
		public Encoding ContentEncoding;

		private string content;

		public HttpResponseBase ()
		{
			this.Cookies = new CookieCollection ();
			this.ContentType = "html";
			this.content = "";
			this.Header = new HttpResponseHeader ();
			this.ContentEncoding = Encoding.UTF8;
		}
		public HttpResponseBase (string content) : this ()
		{
			this.content = content;
		}

		public string Content {
			get => this.content;
			set => this.content = value;
		}

	}
}
