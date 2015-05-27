using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pam.EF5.Entites
{
    [Table("indemnites")]
    public class Indemnites
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [Column("INDICE")]
        public int Indice { get; set; }
        [Required]
        [MaxLength(11)]
        [Column("BASE_HEURE")]
        public double BaseHeure { get; set; }
        [Required]
        [Column("ENTRETIEN_JOUR")]
        public double EntretienJour { get; set; }
        [Required]
        [Column("REPAS_JOUR")]
        public double RepasJour { get; set; }
        [Required]
        [Column("INDEMNITES_CP")]
        public double IndemnitesCp { get; set; }
        [Required]
        [ConcurrencyCheck]
        [Column("VERSIONING")]
        public int? Versioning { get; set; }

        // signature
        public override string ToString()
        {
            return string.Format("Indemnités[{0},{1},{2},{3},{4}, {5}, {6}]", Id, Versioning,
            Indice, BaseHeure, EntretienJour, RepasJour, IndemnitesCp);
        }
    }
}
