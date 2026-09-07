using Bibliotheques.ApplicationCore.Entities;
using Bibliotheques.ApplicationCore.Interfaces;
namespace Bibliotheques.ApplicationCore.Services;
public class EmpruntService : IEmpruntService {
    private readonly IEmpruntRepository _emprunts;
    private readonly ILivreRepository _livres;
    private readonly IUsagerRepository _usagers;
    private readonly int _nombreJoursEmprunt;
    public EmpruntService(IEmpruntRepository emprunts, ILivreRepository livres, IUsagerRepository usagers, int nombreJoursEmprunt) {
        _emprunts = emprunts; _livres = livres; _usagers = usagers; _nombreJoursEmprunt = nombreJoursEmprunt;
    }
    public async Task<Emprunt> InscrireAsync(string noAbonne, int livreId) {
        var usager = await _usagers.GetByNoAbonneAsync(noAbonne) ?? throw new InvalidOperationException("Usager introuvable.");
        var livre = await _livres.GetByIdAsync(livreId) ?? throw new InvalidOperationException("Livre introuvable.");
        if (usager.Defaillance >= 3) throw new InvalidOperationException("Cet usager ne peut plus emprunter : trois défaillances ou plus.");
        if (await _emprunts.CountActiveByUserAsync(noAbonne) >= 3) throw new InvalidOperationException("Un usager ne peut pas avoir plus de trois emprunts en cours.");
        if (await _emprunts.HasActiveLoanForBookAsync(noAbonne, livreId)) throw new InvalidOperationException("L'usager possède déjà un exemplaire de ce livre.");
        if (livre.Quantite <= 0) throw new InvalidOperationException("Aucun exemplaire disponible pour ce livre.");
        var now = DateTime.Now;
        var exemplaire = await _emprunts.GetAvailableExemplaireAsync(livreId);
        var emprunt = new Emprunt { DateEmprunt = now, DateLimiteRetour = now.AddDays(_nombreJoursEmprunt), LivreId = livreId, UsagerNoAbonne = noAbonne, ExemplaireId = exemplaire?.Id };
        livre.Quantite--;
        if (exemplaire != null) exemplaire.Etat = "Emprunté";
        _emprunts.Add(emprunt);
        await _emprunts.SaveChangesAsync();
        return (await _emprunts.GetWithDetailsAsync(emprunt.Id))!;
    }
    public Task<Emprunt?> GetAsync(int id) => _emprunts.GetWithDetailsAsync(id);
    public Task<List<Emprunt>> GetAllAsync() => _emprunts.GetAllWithDetailsAsync();
    public async Task<Emprunt> RetournerAsync(int id) {
        var emprunt = await _emprunts.GetWithDetailsAsync(id) ?? throw new KeyNotFoundException("Emprunt introuvable.");
        if (emprunt.DateRetour.HasValue) throw new InvalidOperationException("Cet emprunt est déjà retourné.");
        var retour = DateTime.Now;
        emprunt.DateRetour = retour;
        if (emprunt.Livre != null) emprunt.Livre.Quantite++;
        if (emprunt.Exemplaire != null) emprunt.Exemplaire.Etat = "Disponible";
        if (retour.Date > emprunt.DateLimiteRetour.Date && emprunt.Usager != null) emprunt.Usager.Defaillance++;
        await _emprunts.SaveChangesAsync();
        return (await _emprunts.GetWithDetailsAsync(id))!;
    }
    public async Task SupprimerAsync(int id) {
        var emprunt = await _emprunts.GetWithDetailsAsync(id) ?? throw new KeyNotFoundException("Emprunt introuvable.");
        if (emprunt.DateRetour.HasValue) throw new InvalidOperationException("Un emprunt retourné ne peut pas être supprimé.");
        if (emprunt.Livre != null) emprunt.Livre.Quantite++;
        if (emprunt.Exemplaire != null) emprunt.Exemplaire.Etat = "Disponible";
        _emprunts.Remove(emprunt);
        await _emprunts.SaveChangesAsync();
    }
}
