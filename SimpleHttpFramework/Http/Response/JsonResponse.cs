using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimpleHttpFramework.Http.Response {
	public class JsonResponse : HttpResponseBase {
		private Object rawObject;

		public JsonResponse ()
		{
			this.rawObject = new Object ();
		}
		public JsonResponse (Object data)
		{
			this.rawObject = data;
		}

		new public string Content => JsonConvert.SerializeObject (this.rawObject);

		public object Object {
			get => this.rawObject;
			set => this.rawObject = value;
		}
	}
}
