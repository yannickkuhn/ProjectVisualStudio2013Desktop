﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class MeteoController : Controller
    {
        // GET: /15/04/2015
        public string Afficher(int jour, int mois, int annee)
        {
            return "Il fait soleil le " + jour + "/" + mois + "/" + annee;
        }
    }
}