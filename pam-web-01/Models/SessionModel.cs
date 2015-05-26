using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pam.Models;

namespace Pam.Models
{
    public class SessionModel
    {
        // la liste des simulations
        public List<Simulation> Simulations { get; set; }
        // n° de la prochaine simulation
        public int NumNextSimulation { get; set; }
        // la dernière simulation
        public Simulation Simulation { get; set; }
        // constructeur
        public SessionModel()
        {
            // liste de simulations vide
            Simulations = new List<Simulation>();
            // n° prochaine simulation
            NumNextSimulation = 1;
        }
    }
}