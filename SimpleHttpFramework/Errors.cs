using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleHttpFramework.Http.Response;

namespace SimpleHttpFramework {
	public class Errors {
		public static HttpResponseServerError UrlNotFound ()
		{
			return new HttpResponseServerError ("UrlNotFound");
		}
	}
}
