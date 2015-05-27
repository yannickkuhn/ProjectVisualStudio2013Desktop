using Pam.EF5.Entites;
using System.Data.Entity;

namespace Pam.Models
{
    public class DbPamContext : DbContext
    {
        public DbSet<Employe> Employes { get; set; }
        public DbSet<Cotisations> Cotisations { get; set; }
        public DbSet<Indemnites> Indemnites { get; set; }
    }
}