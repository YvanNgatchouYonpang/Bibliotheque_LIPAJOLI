using Bibliotheques.ApplicationCore.Entities;
namespace Bibliotheques.ApplicationCore.Interfaces;
public interface IEmpruntRepository : IRepository<Emprunt> {
    Task<List<Emprunt>> GetAllWithDetailsAsync();
    Task<Emprunt?> GetWithDetailsAsync(int id);
    Task<int> CountActiveByUserAsync(string noAbonne);
    Task<bool> HasActiveLoanForBookAsync(string noAbonne, int livreId);
    Task<Exemplaire?> GetAvailableExemplaireAsync(int livreId);
}
