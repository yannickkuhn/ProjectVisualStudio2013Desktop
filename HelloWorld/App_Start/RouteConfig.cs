using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HelloWorld
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Meteo",
                url: "{jour}/{mois}/{annee}",
                defaults: new { controller = "Meteo", action = "Afficher" },
                constraints: new { jour = @"\d+", mois = @"\d+", annee = @"\d+" });

            /*routes.MapRoute(
                name: "Ajouter",
                url: "{action}/{valeur1}/{valeur2}",
                defaults: new { controller = "Calculateur", action = "Ajouter", valeur1 = 0, valeur2 = 0 });*/

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
