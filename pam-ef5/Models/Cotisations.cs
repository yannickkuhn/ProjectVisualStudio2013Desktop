using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pam.EF5.Entites
{
    [Table("cotisations")]
    public class Cotisations
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [Column("CSGRDS")]
        public double CsgRds { get; set; }
        [Required]
        [Column("CSGD")]
        public double Csgd { get; set; }
        [Required]
        [Column("SECU")]
        public double Secu { get; set; }
        [Required]
        [Column("RETRAITE")]
        public double Retraite { get; set; }
        [Required]
        [ConcurrencyCheck]
        [Column("VERSIONING")]
        public int? Versioning { get; set; }

        // signature
        public override string ToString()
        {
            return string.Format("Cotisations[{0},{1},{2},{3}, {4}, {5}]", Id, Versioning,
            CsgRds, Csgd, Secu, Retraite);
        }
    }
}