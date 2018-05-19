using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Router router = new Router();
            router.Add("/test", Controller.Test);

            Server server = new Server(8080);
            server.Router = router;
            server.Run();
        }
    }
}
