using System.ComponentModel.DataAnnotations;
namespace Bibliotheques.ApplicationCore.Entities;
public class Livre {
    [Key] public int Id { get; set; }
    public string? Code { get; set; }
    [Required] public string ISBN10 { get; set; } = "";
    [Required] public string ISBN13 { get; set; } = "";
    [Required] public string Titre { get; set; } = "";
    public string? Auteurs { get; set; }
    [Required] public string Categorie { get; set; } = "";
    [Range(0,int.MaxValue)] public int Quantite { get; set; }
    public decimal Prix { get; set; }
    public ICollection<Emprunt> Emprunts { get; set; } = new List<Emprunt>();
    public ICollection<Exemplaire> Exemplaires { get; set; } = new List<Exemplaire>();
}
