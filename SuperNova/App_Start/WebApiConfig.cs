﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Routing;

namespace SuperNova
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Serviços e configuração da API da Web
            config.EnableCors();
            // Rotas da API da Web
            config.MapHttpAttributeRoutes();
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
