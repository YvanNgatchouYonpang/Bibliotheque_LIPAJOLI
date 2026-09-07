using Bibliotheques.ApplicationCore.Entities;
namespace Bibliotheques.ApplicationCore.Interfaces;
public interface IEmpruntService {
    Task<Emprunt> InscrireAsync(string noAbonne, int livreId);
    Task<Emprunt?> GetAsync(int id);
    Task<List<Emprunt>> GetAllAsync();
    Task<Emprunt> RetournerAsync(int id);
    Task SupprimerAsync(int id);
}
