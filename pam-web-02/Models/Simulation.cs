using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pam.Metier.Entites;

namespace Pam.Models
{
    public class Simulation
    {
        // n° de la simulation
        public int Num { get; set; }
        // le nombre d'heures travaillées
        public double HeuresTravaillées { get; set; }
        // le nombre de jours travaillés
        public int JoursTravaillés { get; set; }
        // la feuille de salaire
        public FeuilleSalaire FeuilleSalaire { get; set; }
    }
}