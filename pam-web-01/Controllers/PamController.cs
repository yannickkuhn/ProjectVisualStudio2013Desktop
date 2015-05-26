using Pam.Metier.Entites;
using Pam.Models;
using PamWeb.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Pam.Controllers
{
    public class PamController : Controller
    {
        [HttpGet]
        public ViewResult Index(ApplicationModel application)
        {
            // erreur d'initialisation ?
            //if (application.InitException != null)
            //{
                // page d'erreurs sans menu
            //    return View("InitFailed", Static.GetErreursForException(application.InitException));
            //}
            // pas d'erreur
            return View(new IndexModel() { Application = application });
        }

        [HttpPost]
        public PartialViewResult FaireSimulation(FormCollection postedData, ApplicationModel application, SessionModel session)
        {
            FeuilleSalaire feuilleSalaire = null;
            Exception exception = null;

            // création du modèle de l'action
            IndexModel modèle = new IndexModel() { Application = application };

            try
            {
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
                // sessions utilisateur
                session.Simulation = new Simulation()
                {
                    Num = session.NumNextSimulation,
                    HeuresTravaillées = modèle.HeuresTravaillées,
                    JoursTravaillés = Convert.ToInt32(modèle.JoursTravaillés),
                    FeuilleSalaire = feuilleSalaire
                };
                // on affiche la feuille de salaire
                return PartialView("Simulation", feuilleSalaire);
            }
            else
            {
                return PartialView("Erreurs", Static.GetErreursForException(exception));
            }
            
        }

        [HttpPost]
        public PartialViewResult EnregistrerSimulation(SessionModel session)
        {
            // on enregistre la dernière simulation faite dans la liste des simulations de la session
            session.Simulations.Add(session.Simulation);
            // on incrémente dans la session le n° de la prochaine simulation
            session.NumNextSimulation++;
            // on affiche la liste des simulations
            return PartialView("Simulations", session.Simulations);
        }
        [HttpPost]
        public PartialViewResult VoirSimulations(SessionModel session)
        {
            return PartialView("Simulations", session.Simulations);
        }

        [HttpPost]
        public PartialViewResult Formulaire(ApplicationModel application)
        {
            return PartialView("Formulaire", new IndexModel() { Application = application });
        }

        [HttpPost]
        public PartialViewResult TerminerSession(ApplicationModel application)
        {
            // effacer les données de la session utilisateur
            Session.Abandon();
            return PartialView("Formulaire", new IndexModel() { Application = application });
        }

        [HttpPost]
        public PartialViewResult RetirerSimulation(SessionModel session, int num)
        {
            session.Simulations.RemoveAt(num-1);
            return PartialView("Simulations", session.Simulations);
        }
    }
}
