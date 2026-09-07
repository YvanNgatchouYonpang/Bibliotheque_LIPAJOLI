namespace Bibliotheques.ApplicationCore.Entities;
public class Emprunt {
    public int Id { get; set; }
    public DateTime DateEmprunt { get; set; }
    public DateTime DateLimiteRetour { get; set; }
    public DateTime? DateRetour { get; set; }
    public int LivreId { get; set; }
    public string UsagerNoAbonne { get; set; } = "";
    public int? ExemplaireId { get; set; }
    public Livre? Livre { get; set; }
    public Usager? Usager { get; set; }
    public Exemplaire? Exemplaire { get; set; }
}
