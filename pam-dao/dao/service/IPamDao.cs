using Pam.EF5.Entites;

namespace Pam.Dao.Service
{
    public interface IPamDao
    {
        // liste de toutes les identités des employés
        Employe[] GetAllIdentitesEmployes();
        // un employé particulier avec ses indemnités
        Employe GetEmploye(string ss);
        // liste de toutes les cotisations
        Cotisations GetCotisations();
    }
}