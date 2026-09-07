using Bibliotheques.API.DTOs;
using Bibliotheques.ApplicationCore.Interfaces;
using Bibliotheques.ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotheques.API.Controllers;

[ApiController, Route("api/[controller]")]
public class EmpruntsController( IEmpruntService service,IUsagerRepository usagers,ILivreRepository livres) : ControllerBase
{
    private static EmpruntDto Map(Emprunt e)
    {
        string titre = "";
        if (e.Livre != null)
        {
            titre = e.Livre.Titre;
        }

        string nomUsager = e.UsagerNoAbonne;

        if (e.Usager != null)
        {
            nomUsager = e.Usager.Prenom + " " + e.Usager.Nom;
        }

        return new EmpruntDto(
            e.Id,
            e.DateEmprunt,
            e.DateLimiteRetour,
            e.DateRetour,
            e.LivreId,
            titre,
            e.UsagerNoAbonne,
            nomUsager,
            e.ExemplaireId);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmpruntDto>>> GetAll()
    {
        var emprunts = await service.GetAllAsync();

        return Ok(emprunts.Select(Map));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<EmpruntDto>> Get(int id)
    {
        var e = await service.GetAsync(id);

        if (e == null)
        {
            return NotFound();
        }

        return Ok(Map(e));
    }

    [HttpPost]
    public async Task<ActionResult<EmpruntDto>> Create(CreateEmpruntDto dto)
    {
        try
        {
            var e = await service.InscrireAsync(dto.NoAbonne, dto.LivreId);

            return CreatedAtAction(
                nameof(Get),
                new { id = e.Id },
                Map(e));
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id:int}/retour")]
    public async Task<ActionResult<EmpruntDto>> Retour(int id)
    {
        try
        {
            var emprunt = await service.RetournerAsync(id);

            return Ok(Map(emprunt));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await service.SupprimerAsync(id);

            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }
}