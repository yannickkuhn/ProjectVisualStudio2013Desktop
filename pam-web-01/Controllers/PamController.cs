using Pam.Metier.Entites;
using Pam.Models;
using PamWeb.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pam.Controllers
{
    public class PamController : Controller
    {
        [HttpGet]
        public ViewResult Index(ApplicationModel application)
        {
            return View(new IndexModel() { Application = application });
        }

        [HttpPost]
        public PartialViewResult FaireSimulation(FormCollection postedData, ApplicationModel application)
        {
            FeuilleSalaire feuilleSalaire = null;
            Exception exception = null;
            try
            {
                // création du modèle de l'action
                IndexModel modèle = new IndexModel() { Application = application };
                // récupération des valeurs postées dans ce modèle
                TryUpdateModel(modèle, postedData);
                // gestion des erreurs
                if (!ModelState.IsValid)
                {
                    // on retourne les erreurs
                    return PartialView("Erreurs", Static.GetErreursForModel(ModelState));
                }
                // calcul salaire
                feuilleSalaire = application.PamMetier.GetSalaire(modèle.SS, modèle.HeuresTravaillées, Convert.ToInt32(modèle.JoursTravaillés));
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            if (exception == null)
            {
                // on affiche la feuille de salaire
                return PartialView("Simulation", feuilleSalaire);
            }
            else
            {
                return PartialView("Erreurs", Static.GetErreursForException(exception));
            }
            
        }

        [HttpPost]
        public PartialViewResult EnregistrerSimulation()
        {
            return PartialView("Simulations");
        }

        [HttpPost]
        public PartialViewResult VoirSimulations()
        {
            return PartialView("Simulations");
        }

        [HttpPost]
        public PartialViewResult Formulaire()
        {
            return PartialView("Formulaire");
        }

        [HttpPost]
        public PartialViewResult TerminerSession()
        {
            return PartialView("Formulaire");
        }
    }
}
