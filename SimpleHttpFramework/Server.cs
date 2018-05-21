using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using SimpleHttpFramework.Http.Response;
using SimpleHttpFramework.Http.Request;

namespace SimpleHttpFramework {
	public class Server {
		private int port = 8080;
		private HttpListener httpListener;
		private Router router;

		public Server ()
		{
			this.httpListener = new HttpListener ();
		}
		public Server (int port) : this ()
		{
			this.port = port;
		}

		public Router Router {
			get => this.router;
			set => this.router = value;
		}

		public void Run ()
		{
			this.httpListener.Prefixes.Add (string.Format ("http://+:{0}/", this.port));
			this.httpListener.Start ();
			this.httpListener.BeginGetContext (new AsyncCallback (GetContext), this.httpListener);
			Console.WriteLine ("Listen Port:" + port);
			Console.Read ();
		}

		/// <summary>
		/// <see langword="async"/> 
		/// todos:
		/// 1. HttpRequest
		/// 	+ From ContentParams to META
		/// </summary>
		/// <param name="ar">Ar.</param>
		private void GetContext (IAsyncResult ar)
		{
			HttpListener httpListener = ar.AsyncState as HttpListener;
			HttpListenerContext context = httpListener.EndGetContext (ar);  //接收到的请求context（一个环境封装体）

			httpListener.BeginGetContext (new AsyncCallback (GetContext), httpListener);  //开始 第二次 异步接收request请求

			HttpListenerRequest request = context.Request;  //接收的request数据
			HttpListenerResponse response = context.Response;  //用来向客户端发送回复

			HttpResponseBase httpResponse;
			string rawData;
			using (StreamReader reader = new StreamReader (request.InputStream)) {
				rawData = reader.ReadToEnd ();
			}

			HttpRequest httpRequest = new HttpRequest {
				Path = request.RawUrl,
				Body = rawData,
				Method = request.HttpMethod,
				ContentEncoding = request.ContentEncoding,
				ContentType = request.ContentType,
			};
			if (this.router.ContainsUrl (request.RawUrl))
				httpResponse = this.router [request.RawUrl] (httpRequest);
			else
				httpResponse = new HttpResponseNotFound ();

			Console.WriteLine ("接收Web请求，Http方法：{0}，RawURL={1}", request.HttpMethod, request.RawUrl);

			response.StatusCode = httpResponse.StatusCode;
			response.ContentType = httpResponse.ContentType;
			response.ContentEncoding = httpResponse.ContentEncoding;
			response.Cookies = httpResponse.Cookies;

			using (Stream output = response.OutputStream)  //发送回复
			{
				byte [] buffer = Encoding.UTF8.GetBytes (httpResponse.Content);
				output.Write (buffer, 0, buffer.Length);
			}
		}
	}
}
