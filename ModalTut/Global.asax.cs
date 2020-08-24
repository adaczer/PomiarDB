﻿using ModalTut.App_Start;
using ModalTut.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ModalTut
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Database.SetInitializer<ModalContext>(new DropCreateDatabaseIfModelChanges<ModalContext>());

            Database.SetInitializer<ModalContext>(new CreateDatabaseIfNotExists<ModalContext>());

            //Database.SetInitializer<ModalContext>(null);


        }
    }
}
