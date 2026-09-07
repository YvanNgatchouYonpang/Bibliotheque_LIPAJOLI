namespace Bibliotheques.ApplicationCore.Entities;
public class Usager {
    public string NoAbonne { get; set; } = "";
    public string Nom { get; set; } = "";
    public string Prenom { get; set; } = "";
    public int Statut { get; set; }
    public int Defaillance { get; set; }
    public string Email { get; set; } = "";
    public ICollection<Emprunt> Emprunts { get; set; } = new List<Emprunt>();
}
