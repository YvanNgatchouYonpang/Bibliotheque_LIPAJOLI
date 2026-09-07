using System.Net.Http.Json;
using LIPAJOLI.Interfaces;
using LIPAJOLI.ViewModels;
namespace LIPAJOLI.Services;
public class EmpruntApiService(HttpClient http) : IEmpruntApiService {
 public async Task<List<EmpruntViewModel>> GetAllAsync()=>await http.GetFromJsonAsync<List<EmpruntViewModel>>("api/emprunts")??[];
 public async Task<EmpruntViewModel?> GetAsync(int id)=>await http.GetFromJsonAsync<EmpruntViewModel>($"api/emprunts/{id}");
 public async Task<(bool,string?,EmpruntViewModel?)> CreateAsync(string no,int livre){var r=await http.PostAsJsonAsync("api/emprunts",new{NoAbonne=no,LivreId=livre});return await Parse(r);}
 public async Task<(bool,string?,EmpruntViewModel?)> RetourAsync(int id){var r=await http.PutAsync($"api/emprunts/{id}/retour",null);return await Parse(r);}
 public async Task<(bool,string?)> DeleteAsync(int id){var r=await http.DeleteAsync($"api/emprunts/{id}");return r.IsSuccessStatusCode?(true,null):(false,await r.Content.ReadAsStringAsync());}
 public async Task<List<LivreViewModel>> GetLivresAsync()=>await http.GetFromJsonAsync<List<LivreViewModel>>("api/livres")??[];
 public async Task<List<UsagerViewModel>> GetUsagersAsync()=>await http.GetFromJsonAsync<List<UsagerViewModel>>("api/usagers")??[];
 private static async Task<(bool,string?,EmpruntViewModel?)> Parse(HttpResponseMessage r){var body=await r.Content.ReadAsStringAsync();if(!r.IsSuccessStatusCode)return(false,body,null);return(true,null,System.Text.Json.JsonSerializer.Deserialize<EmpruntViewModel>(body,new System.Text.Json.JsonSerializerOptions{PropertyNameCaseInsensitive=true}));}
}
