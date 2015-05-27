using Pam.Dao.Entites;
using Pam.EF5.Entites;
using Pam.Models;
using System;
using System.Linq;

namespace Pam.Dao.Service
{
    public class PamDaoEF5 : IPamDao
    {
        // champs privés
        private Cotisations cotisations = null;
        private Employe[] employes = null;
        // Constructeur
        public PamDaoEF5()
        {
            // cotisation
            try
            { 
                using (var context = new DbPamContext())
                {
                    // tous les employés
                    int i = 0;
                    employes = new Employe[context.Employes.Count()];
                    foreach (Employe employe in context.Employes)
                    {
                        employes[i] = employe;
                        i++;
                    }
                    // premier element de la table cotisations
                    cotisations = context.Cotisations.First();
                }
            }
            catch (Exception e)
            {
                throw new PamException("Erreur système lors de la construction de la couche [DAO]", e, 1);
            }
        }
        // GetCotisations
        public Cotisations GetCotisations()
        {
            return cotisations;
        }
        // GetAllIdentitesEmploye
        public Employe[] GetAllIdentitesEmployes()
        {
            return employes;
        }
        // GetEmploye
        public Employe GetEmploye(string SS)
        {
            Employe employe = null;
            try
            {
                using (var context = new DbPamContext())
                {
                    // l'employé au numéro de SS passé en paramètre
                    employe = context.Employes.Include("indemnites").Single<Employe>(c => c.SS == SS);
                }
            }
            catch (Exception e)
            {
                throw new PamException(string.Format("Erreur système lors de la recherche de l'employé [{0}]", SS), e, 2);
            }
            return employe;
        }
    }
}