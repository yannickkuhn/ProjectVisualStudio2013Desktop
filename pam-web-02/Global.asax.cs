using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Pam.Metier.Entites;
using Pam.Metier.Service;
using Pam.Infrastructure;
using Pam.Models;
using System.Configuration;

using Spring.Context.Support;
using Pam.EF5.Entites;


namespace Pam
{
    // Remarque : pour obtenir des instructions sur l'activation du mode classique IIS6 ou IIS7, 
    // visitez http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // initialisation application
            Application["infoAppli"] = ConfigurationManager.AppSettings["infoAppli"];

            // -------------------------------------------------------------------
            // ---------- configuration spécifique
            // -------------------------------------------------------------------
            // données de portée application
            ApplicationModel application = new ApplicationModel();
            Application["data"] = application;
            // instanciation couche [métier] - utilisation de Spring FRAMEWORK (amélioration)
            application.InitException = null;
            try
            {
                // instanciation couche [métier]
                application.PamMetier = (IPamMetier)ContextRegistry.GetContext().GetObject("pammetier");
            }
            catch (Exception ex)
            {
                application.InitException = ex;
            }
            //si pas d'erreur
            if (application.InitException == null)
            {
                // tableau des employés
                application.Employes = application.PamMetier.GetAllIdentitesEmployes();
                // éléments du combo des employés

                // transformation du tableau d'employés en liste déroulante
                SelectListItem[] listEmployes = new SelectListItem[application.Employes.Length];
                for (int i = 0; i < application.Employes.Length; i++)
                {
                    Employe iEmploye = application.Employes[i];
                    listEmployes[i] = new SelectListItem() { Text = iEmploye.Prenom + " " + iEmploye.Nom, Value = iEmploye.SS };
                }
                application.EmployesItems = listEmployes;

            }

            // model binders pour [ApplicationModel et SessionModel]
            ModelBinders.Binders.Add(typeof(ApplicationModel), new ApplicationModelBinder());
            ModelBinders.Binders.Add(typeof(SessionModel), new SessionModelBinder());
        }

        protected void Session_Start()
        {
            // initialisation d'un compteur
            Session["compteur"] = 0;
            // initialisation de la session des données avec notre modèle
            Session["data"] = new SessionModel();
        }
    }
}