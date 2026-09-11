using Bibliotheques.ApplicationCore.Entities;
using Bibliotheques.ApplicationCore.Interfaces;
using Bibliotheques.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Bibliotheques.Infrastructure.Repositories;
public class EmpruntRepository(BibliothequeDbContext c) : Repository<Emprunt>(c), IEmpruntRepository
{
    public Task<List<Emprunt>> GetAllWithDetailsAsync() => Context.Emprunts
        .Include(x => x.Livre).Include(x => x.Usager).Include(x => x.Exemplaire).OrderByDescending(x => x.DateEmprunt).ToListAsync();
    public Task<Emprunt?> GetWithDetailsAsync(int id) => Context.Emprunts
        .Include(x => x.Livre).Include(x => x.Usager).Include(x => x.Exemplaire).FirstOrDefaultAsync(x => x.Id == id);
    public async Task<int> CountActiveByUserAsync(string noAbonne)
    {
        return await Context.Emprunts
            .CountAsync(e =>
                e.UsagerNoAbonne == noAbonne &&
                e.DateRetour == null);
    }
    public Task<bool> HasActiveLoanForBookAsync(string n, int livreId) => Context.Emprunts
        .AnyAsync(x => x.UsagerNoAbonne == n && x.LivreId == livreId && x.DateRetour == null);
    public async Task<Exemplaire?> GetAvailableExemplaireAsync(int livreId)
    {
        return await Context.Exemplaires
            .Where(e =>
                e.LivreId == livreId &&
                e.Etat == "Disponible" &&
                !e.Emprunts.Any(emprunt =>
                    emprunt.DateRetour == null))
            .FirstOrDefaultAsync();
    }
}
