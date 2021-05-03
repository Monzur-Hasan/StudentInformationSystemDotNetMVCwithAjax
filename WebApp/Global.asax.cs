using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using AutoMapper;
using WebApp.Model.Model;
using WebApp.Models;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Initialize
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<StudentViewModel, Student>();  //.CreateMap<StudentViewModel to object Student>

                cfg.CreateMap<Student, StudentViewModel>();  //.CreateMap< object Student to StudentViewModel  >
            });
            //.CreateMap<TSource, TDestination>();

        }
    }
}

//4 steps of Configure AutoMapper-> 1. Install Install-Package AutoMapper -Version 8.0.0
//2. Add namespace 3. Mapper Initialize    4. Configure