using LIPAJOLI.Interfaces;
using LIPAJOLI.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace LIPAJOLI.Controllers;
public class EmpruntsController(IEmpruntApiService api):Controller {
 public async Task<IActionResult> Index()=>View(await api.GetAllAsync());
 public async Task<IActionResult> Details(int id){var e=await api.GetAsync(id);return e is null?NotFound():View(e);}
 public async Task<IActionResult> Create(){ViewBag.Livres=await api.GetLivresAsync();ViewBag.Usagers=await api.GetUsagersAsync();return View(new CreateEmpruntViewModel());}
 [HttpPost,ValidateAntiForgeryToken] public async Task<IActionResult> Create(CreateEmpruntViewModel model){if(!ModelState.IsValid){ViewBag.Livres=await api.GetLivresAsync();ViewBag.Usagers=await api.GetUsagersAsync();return View(model);}var r=await api.CreateAsync(model.NoAbonne,model.LivreId);if(!r.Item1){ModelState.AddModelError("",r.Item2??"Impossible de créer l'emprunt.");ViewBag.Livres=await api.GetLivresAsync();ViewBag.Usagers=await api.GetUsagersAsync();return View(model);}return RedirectToAction(nameof(Index));}
 [HttpPost,ValidateAntiForgeryToken] public async Task<IActionResult> Retour(int id){var r=await api.RetourAsync(id);if(!r.Item1)TempData["Error"]=r.Item2;return RedirectToAction(nameof(Index));}
 public async Task<IActionResult> Delete(int id){var e=await api.GetAsync(id);return e is null?NotFound():View(e);}
 [HttpPost,ActionName("Delete"),ValidateAntiForgeryToken] public async Task<IActionResult> DeleteConfirmed(int id){var r=await api.DeleteAsync(id);if(!r.Success)TempData["Error"]=r.Error;return RedirectToAction(nameof(Index));}
}
