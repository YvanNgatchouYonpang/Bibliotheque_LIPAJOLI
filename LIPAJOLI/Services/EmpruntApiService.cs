using System.Net.Http.Json;
using LIPAJOLI.Interfaces;
using LIPAJOLI.ViewModels;

namespace LIPAJOLI.Services;

public class EmpruntApiService : IEmpruntApiService
{
    private readonly HttpClient http;

    public EmpruntApiService(HttpClient http)
    {
        this.http = http;
    }

    public async Task<List<EmpruntViewModel>> GetAllAsync()
    {
        var result = await http.GetFromJsonAsync<List<EmpruntViewModel>>(
            "api/emprunts");

        if (result == null)
        {
            return new List<EmpruntViewModel>();
        }

        return result;
    }

    public async Task<EmpruntViewModel?> GetAsync(int id)
    {
        var result = await http.GetFromJsonAsync<EmpruntViewModel>(
            $"api/emprunts/{id}");

        return result;
    }

    public async Task<(bool, string?, EmpruntViewModel?)> CreateAsync(
        string no,
        int livre)
    {
        var data = new
        {
            NoAbonne = no,
            LivreId = livre
        };

        var response = await http.PostAsJsonAsync(
            "api/emprunts",
            data);

        return await Parse(response);
    }

    public async Task<(bool, string?, EmpruntViewModel?)> RetourAsync(int id)
    {
        var response = await http.PutAsync(
            $"api/emprunts/{id}/retour",
            null);

        return await Parse(response);
    }

    public async Task<(bool, string?)> DeleteAsync(int id)
    {
        var response = await http.DeleteAsync(
            $"api/emprunts/{id}");

        if (response.IsSuccessStatusCode)
        {
            return (true, null);
        }

        var message = await response.Content.ReadAsStringAsync();

        return (false, message);
    }

    public async Task<List<LivreViewModel>> GetLivresAsync()
    {
        var result = await http.GetFromJsonAsync<List<LivreViewModel>>(
            "api/livres");

        if (result == null)
        {
            return new List<LivreViewModel>();
        }

        return result;
    }

    public async Task<List<UsagerViewModel>> GetUsagersAsync()
    {
        var result = await http.GetFromJsonAsync<List<UsagerViewModel>>(
            "api/usagers");

        if (result == null)
        {
            return new List<UsagerViewModel>();
        }

        return result;
    }

    private static async Task<(bool, string?, EmpruntViewModel?)> Parse(
        HttpResponseMessage response)
    {
        var body = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            return (false, body, null);
        }

        var options = new System.Text.Json.JsonSerializerOptions();

        options.PropertyNameCaseInsensitive = true;

        var emprunt =
            System.Text.Json.JsonSerializer.Deserialize<EmpruntViewModel>(
                body,
                options);

        return (true, null, emprunt);
    }
}