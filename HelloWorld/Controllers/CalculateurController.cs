using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class CalculateurController : Controller
    {
        // GET: /Ajouter/1/2
        public string Ajouter(int valeur1, int valeur2)
        {
            int resultat = valeur1 + valeur2;
            return resultat.ToString();
        }

        // GET: /Soustraire/1/2
        public string Soustraire(int? valeur1, int? valeur2)
        {
            return (valeur1 - valeur2).ToString();
        }
    }
}