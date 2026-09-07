namespace LIPAJOLI.ViewModels;
public class EmpruntViewModel { public int Id{get;set;} public DateTime DateEmprunt{get;set;} public DateTime DateLimiteRetour{get;set;} public DateTime? DateRetour{get;set;} public int LivreId{get;set;} public string Livre{get;set;}=""; public string NoAbonne{get;set;}=""; public string Usager{get;set;}=""; public int? ExemplaireId{get;set;} }
public class LivreViewModel { public int Id{get;set;} public string? Code{get;set;} public string Titre{get;set;}=""; public int Quantite{get;set;} }
public class UsagerViewModel { public string NoAbonne{get;set;}=""; public string Nom{get;set;}=""; public string Prenom{get;set;}=""; public int Defaillance{get;set;} public string Email{get;set;}=""; }
public class CreateEmpruntViewModel { public string NoAbonne{get;set;}=""; public int LivreId{get;set;} }
