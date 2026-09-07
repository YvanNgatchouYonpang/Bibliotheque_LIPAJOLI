using Bibliotheques.ApplicationCore.Entities;
using Bibliotheques.ApplicationCore.Interfaces;
using Bibliotheques.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Bibliotheques.Infrastructure.Repositories;
public class UsagerRepository(BibliothequeDbContext c) : Repository<Usager>(c), IUsagerRepository {
    public Task<Usager?> GetByNoAbonneAsync(string noAbonne)=>Context.Usagers.FirstOrDefaultAsync(x=>x.NoAbonne==noAbonne);
}
