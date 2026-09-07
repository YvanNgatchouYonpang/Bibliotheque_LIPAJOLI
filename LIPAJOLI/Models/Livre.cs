using System.ComponentModel.DataAnnotations;

namespace LIPAJOLI.Models
{
    public class Livre
    {
        [Key]
        public int Id {  get; set; }

        public string? Code { get; set; }

        [Required(ErrorMessage = "Le champ est obligatoire")]
        [DataType(DataType.Text)]
        [Display(Name = "ISBN-10")]
        [RegularExpression(@"(?=[0-9X]{10}$|(?=(?:[0-9]+[-\ ]){3})[-\ 0-9X]{13}$)[0-9]{1,5}[-\]?[0-9]+[-\]?[0-9]+[-\]?[0-9X]$", ErrorMessage = "Vous devez entrer une valeur de ISBN10 valide. Il est possible de séparer les caractères avec un trait d'union.")]
        public string ISBN10 { get; set; }


        [Required(ErrorMessage = "Le champ est obligatoire")]
        [DataType(DataType.Text)]
        [Display(Name = "ISBN-13")]
        [RegularExpression(@"(?=[0-9]{13}$|(?=(?:[0-9]+[-\ ]){4})[-\ 0-9]{17}$)97[89][-\ ]?[0-9]{1,5}[-\ ]?[0-9]+[-\ ]?[0-9]+[-\ ]?[0-9]$", ErrorMessage = "Vous devez entrer une valeur de ISBN13 valide. Il est possible de séparer les caractères avec un trait d'union.")]
        public string ISBN13 { get; set; }

        [Required(ErrorMessage = "Le titre est obligatoire.")]
        [StringLength(200, ErrorMessage = "Le titre ne peut pas dépasser 200 caractères.")]
        public string Titre { get; set; } 

        //[Required(ErrorMessage = "Au moins un auteur est obligatoire.")]
        public string? Auteurs { get; set; } 

        [Required(ErrorMessage = "La catégorie est obligatoire.")]
        public string Categorie { get; set; } 

        [Range(0, int.MaxValue,
            ErrorMessage = "La quantité doit être supérieure ou égale à 0.")]
        [Required(ErrorMessage = "La quantite est obligatoire.")]
        public int Quantite { get; set; }

        [Range(0.01, double.MaxValue,
            ErrorMessage = "Le prix doit être supérieur à 0.")]
        [Required(ErrorMessage = "Le prix est obligatoire.")]
        public decimal Prix { get; set; }

        public ICollection<Emprunt> Emprunts { get; set; }
            = new List<Emprunt>();

    }
}
