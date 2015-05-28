using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pam.Models
{
    [Bind(Exclude = "Application")]
    public class IndexModel
    {
        // données de portée application
        public ApplicationModel Application { get; set; }
        // valeurs postées
        [Display(Name = "Employé")]
        public string SS { get; set; }
        [Display(Name = "Heures travaillées")]
        [Required(ErrorMessage = "Le nombre d'heures travaillées est requis !")]
        [RegularExpression(@"^(-|)\d+((.|,)\d+|)$", ErrorMessage = "Le champ Heures travaillées doit être un nombre.")]
        [Range(0, 400, ErrorMessage = "Le nombre d'heures doit être dans l'intervalle [0,400] !")]
        [UIHint("Decimal")]
        public double HeuresTravaillées { get; set; }
        [Display(Name = "Jours travaillés")]
        [Required(ErrorMessage = "Le nombre de jours travaillés est requis !")]
        [RegularExpression(@"^(-|)\d{1,2}$", ErrorMessage = "Le nombre de jours doit avoir un ou deux chiffres !")]
        [Range(0, 31, ErrorMessage = "Le nombre de jours doit être dans l'intervalle [0,31] !")]
        public double JoursTravaillés { get; set; }
    }
}