using MebelTemplate.DAL;
using MebelTemplate.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MebelTemplate
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_AuthenticateRequest()
        {
            if (User==null){ return; }

            string username = Context.User.Identity.Name;
            string[] rols = null;
            using (Db db=new Db())
            {
                UserDTO dto = db.Users.FirstOrDefault(x => x.Username == username);
                rols = db.UserRols.Where(x => x.UserId == dto.Id).Select(b => b.Role.Name).ToArray();
            }
            IIdentity userIdentitiy = new GenericIdentity(username);
            IPrincipal userObj= new GenericPrincipal(userIdentitiy, rols);
            Context.User = userObj;
        }
    }
}
