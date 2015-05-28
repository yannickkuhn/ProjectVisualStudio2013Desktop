using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return View("Error");
            else
            {
                ViewBag.Nom = id;
                return View();
            }
        }

        public ActionResult ListeClients()
        {
            Client clients = new Client();
            ViewData["Clients"] = clients.ObtenirListeClients();
            return View();
        }

        public ActionResult ChercheClient(string id)
        {
            ViewData["Nom"] = id;
            Client clients = new Client();
            Client client = clients.ObtenirListeClients().FirstOrDefault(c => c.Nom == id);
            if (client != null)
            {
                ViewData["Age"] = client.Age;
                return View("Trouve");
            }
            return View("NonTrouve");
        }
	}
}