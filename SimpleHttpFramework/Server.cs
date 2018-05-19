using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace SimpleHttpFramework
{
    public class Server
    {
        private int port = 8080;
        private HttpListener httpListener;
        private Router router;

        public Server()
        {
            this.httpListener = new HttpListener();
        }
        public Server(int port) : this()
        {
            this.port = port;
        }

        public Router Router
        {
            get => this.router;
            set => this.router = value;
        }

        public void Run()
        {
            this.httpListener.Prefixes.Add(string.Format("http://+:{0}/", this.port));
            this.httpListener.Start();
            this.httpListener.BeginGetContext(new AsyncCallback(GetContext), this.httpListener);
            Console.WriteLine("监听端口:" + port);
            Console.Read();
        }

        private void GetContext(IAsyncResult ar)
        {
            HttpListener httpListener = ar.AsyncState as HttpListener;
            HttpListenerContext context = httpListener.EndGetContext(ar);  //接收到的请求context（一个环境封装体）

            httpListener.BeginGetContext(new AsyncCallback(GetContext), httpListener);  //开始 第二次 异步接收request请求

            HttpListenerRequest request = context.Request;  //接收的request数据
            HttpListenerResponse response = context.Response;  //用来向客户端发送回复

            HttpResponse httpResponse;
            string rawData;
            using (StreamReader reader = new StreamReader(request.InputStream))
            {
                rawData = reader.ReadToEnd();
            }

            if (this.router.ContainsUrl(request.RawUrl))
                httpResponse = this.router[request.RawUrl](new HttpRequest(request.HttpMethod, rawData));
            else
                httpResponse = Error.UrlNotFound();

            Console.WriteLine("接收Web请求，Http方法：{0}，RawURL={1}", request.HttpMethod, request.RawUrl);

            response.ContentType = "html";
            response.ContentEncoding = Encoding.UTF8;

            using (Stream output = response.OutputStream)  //发送回复
            {
                byte[] buffer = Encoding.UTF8.GetBytes(httpResponse.Data);
                output.Write(buffer, 0, buffer.Length);               
            }
        }
    }
}
