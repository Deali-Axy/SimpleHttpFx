using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpFramework {
	class Program {
		static void Main (string [] args)
		{
			Router router = new Router ();
			router.Add ("/test", Controller.Test);
			router.Add ("/hello", Controller.Hello);

			Server server = new Server (8080);
			server.Router = router;
			server.Run ();

			Console.WriteLine ("server is running...");
			Console.ReadLine ();
		}
	}
}
