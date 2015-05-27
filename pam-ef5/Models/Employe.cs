using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pam.EF5.Entites
{
    [Table("employes")]
    public class Employe
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [Column("SS")]
        public string SS { get; set; }
        [Required]
        [MaxLength(15)]
        [Column("NOM")]
        public string Nom { get; set; }
        [Required]
        [MaxLength(30)]
        [Column("PRENOM")]
        public string Prenom { get; set; }
        [Required]
        [MaxLength(20)]
        [Column("ADRESSE")]
        public string Adresse { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("VILLE")]
        public string Ville { get; set; }
        [Required]
        [MaxLength(30)]
        [Column("CP")]
        public string CodePostal { get; set; }
        [Required]
        [MaxLength(5)]
        [ConcurrencyCheck]
        [Column("VERSIONING")]
        public int? Versioning { get; set; }


        // clé étrangère : INDEMNITE_ID (virtual)
        [Column("INDEMNITE_ID")]
        public int IndemniteId { get; set; }
        [Required]
        [ForeignKey("IndemniteId")]
        public virtual Indemnites Indemnites { get; set; }

        // signature
        public override string ToString()
        {
            return string.Format("Employé[{0},{1},{2},{3},{4},{5}, {6}, {7}]", Id, Versioning,
            SS, Nom, Prenom, Adresse, Ville, CodePostal);
        }
    }
}
