using System;
using Pam.Metier.Entites;
using Pam.EF5.Entites;
using Pam.Dao.Service;
using Spring.Context.Support;
using Pam.Dao.Entites;

namespace Pam.Metier.Service
{
    public class PamMetier : IPamMetier
    {
        // référence sur la couche [DAO] initialisée par Spring
        public IPamDao PamDao { get; set; }

        // liste de toutes les identités des employés
        public Employe[] GetAllIdentitesEmployes()
        {
            Employe[] employes = null;
            try
            {
                // instanciation couche [dao]
                PamDao = (IPamDao)ContextRegistry.GetContext().GetObject("pamdao");
                // liste des identités des employés
                employes = PamDao.GetAllIdentitesEmployes();
            }
            catch (Exception ex)
            {
                // affichage exception
                Console.WriteLine(ex.ToString());
            }
            return employes;
        }

        // un employé particulier avec ses indemnités
        public Employe GetEmploye(string ss)
        {
            Employe employe = null;
            try
            {
                // instanciation couche [dao]
                PamDao = (IPamDao)ContextRegistry.GetContext().GetObject("pamdao");
                // liste des identités des employés
                employe = PamDao.GetEmploye(ss);
            }
            catch (Exception ex)
            {
                // affichage exception
                Console.WriteLine(ex.ToString());
            }
            return employe;
        }

        // les cotisations
        public Cotisations GetCotisations()
        {
            Cotisations cotisations = null;
            try
            {
                // instanciation couche [dao]
                PamDao = (IPamDao)ContextRegistry.GetContext().GetObject("pamdao");
                // liste des identités des employés
                cotisations = PamDao.GetCotisations();
            }
            catch (Exception ex)
            {
                // affichage exception
                Console.WriteLine(ex.ToString());
            }
            return cotisations;
        }

        // calcul salaire
        public FeuilleSalaire GetSalaire(string ss, double heuresTravaillées, int joursTravaillés)
        {
            // SS : n° SS de l'employé
            // HeuresTravaillées : le nombre d'heures travaillés
            // Jours Travaillés : nbre de jours travaillés
            Employe e = GetEmploye(ss);
            Cotisations c = GetCotisations();
            if (e == null)
            {
                throw new PamException(string.Format("L'employé de n° SS [{0}] n'existe pas", ss), 10);
            }

            // calculs
            double sbase = System.Math.Round((heuresTravaillées * e.Indemnites.BaseHeure) * (1 + e.Indemnites.IndemnitesCp / 100), 2);
            double csociales = System.Math.Round(sbase * ( c.CsgRds + c.Csgd + c.Secu + c.Retraite ) / 100, 2);
            double indemnites = System.Math.Round(joursTravaillés * ( e.Indemnites.EntretienJour + e.Indemnites.RepasJour ), 2);
            double snet = sbase - csociales + indemnites;

            // retours
            return new FeuilleSalaire()
            {
                Employe = e,
                Cotisations = c,
                ElementsSalaire = new ElementsSalaire()
                {
                    CotisationsSociales = csociales,
                    IndemnitesEntretien = indemnites,
                    IndemnitesRepas = indemnites,
                    SalaireBase = sbase,
                    SalaireNet = snet
                }
            };
        }
    }
}
