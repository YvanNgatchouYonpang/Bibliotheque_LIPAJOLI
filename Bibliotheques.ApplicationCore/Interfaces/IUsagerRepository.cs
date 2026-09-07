using Bibliotheques.ApplicationCore.Entities;
namespace Bibliotheques.ApplicationCore.Interfaces;
public interface IUsagerRepository : IRepository<Usager> {
    Task<Usager?> GetByNoAbonneAsync(string noAbonne);
}
