using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace SimpleHttpFramework.Http.Request {
	public class HttpRequest {
		/// <summary>
		/// A string representing the scheme of the request (http or https usually).
		/// </summary>
		public string Scheme;

		/// <summary>
		/// A string representing the full path to the requested page, not including the scheme or domain.
		/// Example: "/music/bands/the_beatles/"
		/// </summary>
		public string Path;

		/// <summary>
		/// The raw HTTP request body as a byte string.
		/// This is useful for processing data in different ways than conventional HTML forms: binary images, XML payload etc
		/// </summary>
		public string Body;

		/// <summary>
		/// A string representing the HTTP method used in the request. This is guaranteed to be uppercase.
		/// For example: post/get
		/// </summary>
		public string Method;

		/// <summary>
		/// the current encoding used to decode form submission data.
		/// </summary>
		public Encoding ContentEncoding;

		/// <summary>
		/// A string representing the MIME type of the request, parsed from the CONTENT_TYPE header.
		/// </summary>
		public string ContentType;

		/// <summary>
		/// A dictionary of key/value parameters included in the CONTENT_TYPE header.
		/// </summary>
		public string ContentParams;

		/// <summary>
		/// A dictionary-like object containing all given HTTP GET parameters.
		/// </summary>
		public Dictionary<string, string> GET;

		/// <summary>
		/// A dictionary-like object containing all given HTTP POST parameters, providing that the request contains form data.
		/// </summary>
		public Dictionary<string, string> POST;

		/// <summary>
		/// A dictionary-like object containing all given HTTP POST parameters, providing that the request contains form data.
		/// </summary>
		public Dictionary<string, string> COOKIES;

		/// <summary>
		/// A dictionary-like object containing all uploaded files.
		/// </summary>
		public Dictionary<string, FileStream> FILES;

		/// <summary>
		/// A dictionary containing all available HTTP headers. Available headers depend on the client and server, but here are some examples:
		/// CONTENT_LENGTH – The length of the request body (as a string).
		/// CONTENT_TYPE – The MIME type of the request body.
		/// HTTP_ACCEPT – Acceptable content types for the response.
		/// HTTP_ACCEPT_ENCODING – Acceptable encodings for the response.
		/// HTTP_ACCEPT_LANGUAGE – Acceptable languages for the response.
		/// HTTP_HOST – The HTTP Host header sent by the client.
		/// HTTP_REFERER – The referring page, if any.
		/// HTTP_USER_AGENT – The client’s user-agent string.
		/// QUERY_STRING – The query string, as a single (unparsed) string.
		/// REMOTE_ADDR – The IP address of the client.
		/// REMOTE_HOST – The hostname of the client.
		/// REMOTE_USER – The user authenticated by the Web server, if any.
		/// REQUEST_METHOD - A string such as "GET" or "POST".
		/// SERVER_NAME – The hostname of the server.	
		/// SERVER_PORT – The port of the server (as a string).
		/// </summary>
		public Dictionary<string, string> META;

		public HttpRequest () { }
		public HttpRequest (string method, string body)
		{
			this.Method = method;
			this.Body = body;
		}
	}
}
