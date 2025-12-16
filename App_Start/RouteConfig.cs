using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Ignora arquivos de sistema (não mexer)
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // --- A ROTA MÁGICA (DEFAULT) ---
            // Essa única regra abaixo resolve TODOS os seus controllers e ações.
            // Ela diz: "O primeiro nome na URL é o Controller, o segundo é a Ação, o terceiro é o ID".

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",  // Aqui define qual tela abre primeiro ao dar Play
                    action = "Index",       // Geralmente é a listagem
                    id = UrlParameter.Optional // O ID é opcional (Index não usa, Delete usa)
                }
            );
        }
    }
}