using LIPAJOLI.ViewModels;
namespace LIPAJOLI.Interfaces;
public interface IEmpruntApiService {
 Task<List<EmpruntViewModel>> GetAllAsync();
 Task<EmpruntViewModel?> GetAsync(int id);
 Task<(bool Success,string? Error,EmpruntViewModel? Emprunt)> CreateAsync(string noAbonne,int livreId);
 Task<(bool Success,string? Error,EmpruntViewModel? Emprunt)> RetourAsync(int id);
 Task<(bool Success,string? Error)> DeleteAsync(int id);
 Task<List<LivreViewModel>> GetLivresAsync();
 Task<List<UsagerViewModel>> GetUsagersAsync();
}
