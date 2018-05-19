using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpFramework
{
    public class Router
    {
        public delegate HttpResponse ControllerMethod(HttpRequest request);
        private Dictionary<string, ControllerMethod> routerTable;

        public Router()
        {
            this.routerTable = new Dictionary<string, ControllerMethod>();
        }

        public ControllerMethod this[string index] => this.routerTable.ContainsKey(index) ? this.routerTable[index] : null;

        public void Add(string url, ControllerMethod method)
        {
            if (!this.routerTable.ContainsKey(url))
                this.routerTable.Add(url, method);
        }

        public bool ContainsUrl(string url) => this.routerTable.ContainsKey(url);
    }
}
