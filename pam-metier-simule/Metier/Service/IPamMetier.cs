﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pam.Metier.Entites;

namespace Pam.Metier.Service
{
    public interface IPamMetier
    {
        // liste de toutes les identités des employés
        Employe[] GetAllIdentitesEmployes();

        // ------- le calcul du salaire
        FeuilleSalaire GetSalaire(string ss, double heuresTravaillées, int joursTravaillés);
    }
}
