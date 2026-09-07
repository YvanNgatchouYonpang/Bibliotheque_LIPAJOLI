namespace Bibliotheques.ApplicationCore.Entities;
public class Exemplaire {
    public int Id { get; set; }
    public string Etat { get; set; } = "Disponible";
    public string? CodeLivre { get; set; }
    public int? LivreId { get; set; }
    public Livre? Livre { get; set; }
    public ICollection<Emprunt> Emprunts { get; set; } = new List<Emprunt>();
}
