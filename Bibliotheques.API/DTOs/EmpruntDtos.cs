namespace Bibliotheques.API.DTOs;

public class CreateEmpruntDto
{
    public string NoAbonne { get; set; }
    public int LivreId { get; set; }

    public CreateEmpruntDto(string noAbonne, int livreId)
    {
        NoAbonne = noAbonne;
        LivreId = livreId;
    }
}

public class EmpruntDto
{
    public int Id { get; set; }
    public DateTime DateEmprunt { get; set; }
    public DateTime DateLimiteRetour { get; set; }
    public DateTime? DateRetour { get; set; }
    public int LivreId { get; set; }
    public string Livre { get; set; }
    public string NoAbonne { get; set; }
    public string Usager { get; set; }
    public int? ExemplaireId { get; set; }

    public EmpruntDto(
        int id,
        DateTime dateEmprunt,
        DateTime dateLimiteRetour,
        DateTime? dateRetour,
        int livreId,
        string livre,
        string noAbonne,
        string usager,
        int? exemplaireId)
    {
        Id = id;
        DateEmprunt = dateEmprunt;
        DateLimiteRetour = dateLimiteRetour;
        DateRetour = dateRetour;
        LivreId = livreId;
        Livre = livre;
        NoAbonne = noAbonne;
        Usager = usager;
        ExemplaireId = exemplaireId;
    }
}

public class LivreDto
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string Titre { get; set; }
    public string? Auteurs { get; set; }
    public string Categorie { get; set; }
    public int Quantite { get; set; }

    public LivreDto(
        int id,
        string? code,
        string titre,
        string? auteurs,
        string categorie,
        int quantite)
    {
        Id = id;
        Code = code;
        Titre = titre;
        Auteurs = auteurs;
        Categorie = categorie;
        Quantite = quantite;
    }
}

public class UsagerDto
{
    public string NoAbonne { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public int Defaillance { get; set; }
    public string Email { get; set; }

    public UsagerDto(
        string noAbonne,
        string nom,
        string prenom,
        int defaillance,
        string email)
    {
        NoAbonne = noAbonne;
        Nom = nom;
        Prenom = prenom;
        Defaillance = defaillance;
        Email = email;
    }
}