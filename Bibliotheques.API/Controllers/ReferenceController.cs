using Bibliotheques.API.DTOs;
using Bibliotheques.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace Bibliotheques.API.Controllers;
[ApiController, Route("api")]
public class ReferenceController(ILivreRepository livres,IUsagerRepository usagers):ControllerBase {
 [HttpGet("livres")] public async Task<ActionResult<IEnumerable<LivreDto>>> Livres()=>Ok((await livres.GetAllAsync()).Select(x=>new LivreDto(x.Id,x.Code,x.Titre,x.Auteurs,x.Categorie,x.Quantite)));
 [HttpGet("usagers")] public async Task<ActionResult<IEnumerable<UsagerDto>>> Usagers()=>Ok((await usagers.GetAllAsync()).Select(x=>new UsagerDto(x.NoAbonne,x.Nom,x.Prenom,x.Defaillance,x.Email)));
}
