using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class ApplicatonRouter
    {
        public static Task DefaultRouteing(HttpContext context)
        {
            var className = Convert.ToString(context.GetRouteValue("class"));
            var methodName = Convert.ToString(context.GetRouteValue("method"));

            var classe = Type.GetType(className);
            var method = classe.GetMethods().Where(m => m.Name == methodName).First();
            var RequestDelagate = (RequestDelegate)Delegate.CreateDelegate(typeof(RequestDelegate),method);

            return RequestDelagate.Invoke(context);
        }
    }
}
