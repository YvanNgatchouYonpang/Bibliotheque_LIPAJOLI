namespace Bibliotheques.API.DTOs;
public record CreateEmpruntDto(string NoAbonne, int LivreId);
public record EmpruntDto(int Id, DateTime DateEmprunt, DateTime DateLimiteRetour, DateTime? DateRetour, int LivreId, string Livre, string NoAbonne, string Usager, int? ExemplaireId);
public record LivreDto(int Id, string? Code, string Titre, string? Auteurs, string Categorie, int Quantite);
public record UsagerDto(string NoAbonne, string Nom, string Prenom, int Defaillance, string Email);
