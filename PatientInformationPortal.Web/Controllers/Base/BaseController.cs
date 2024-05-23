using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace PatientInformationPortal.Web.Controllers.Base;

public class BaseController : Controller
{
    protected readonly HttpClient _client;

    protected BaseController(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient("ApiClient");
    }

    protected async Task<T> GetEntityAsync<T>(string endpoint)
    {
        HttpResponseMessage response = await _client.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();
        string data = await response.Content.ReadAsStringAsync();
        try
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
        catch (JsonException ex)
        {
            throw new Exception($"Error deserializing JSON data: {ex.Message}", ex);
        }
    }

    protected async Task<T> InsertEntityAsync<T>(string endpoint, T entity)
    {
        string jsonData = JsonConvert.SerializeObject(entity);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _client.PostAsync(endpoint, content);
        response.EnsureSuccessStatusCode();

        string data = await response.Content.ReadAsStringAsync();
        try
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
        catch (JsonException ex)
        {
            throw new Exception($"Error deserializing JSON data: {ex.Message}", ex);
        }
    }

    protected async Task<T> UpdateEntityAsync<T>(string endpoint, T entity)
    {
        string jsonData = JsonConvert.SerializeObject(entity);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _client.PutAsync(endpoint, content);
        response.EnsureSuccessStatusCode();

        string data = await response.Content.ReadAsStringAsync();
        try
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
        catch (JsonException ex)
        {
            throw new Exception($"Error deserializing JSON data: {ex.Message}", ex);
        }
    }

    protected async Task DeleteEntityAsync(string endpoint)
    {
        HttpResponseMessage response = await _client.DeleteAsync(endpoint);
        response.EnsureSuccessStatusCode();
    }
}
