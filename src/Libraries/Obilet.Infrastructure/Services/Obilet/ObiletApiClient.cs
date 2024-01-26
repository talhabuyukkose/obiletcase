using System.Net.Mime;
using System.Text;
using System.Text.Json;
using Obilet.Core.Constants;
using Obilet.Core.Interfaces;

namespace Obilet.Infrastructure.Services.Obilet;

public class ObiletApiClient : IObiletApiClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ObiletApiClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    /// <summary>
    /// Post a request to OBiletApi
    /// </summary>
    /// <param name="url"></param>
    /// <param name="request"></param>
    /// <typeparam name="TResponse"></typeparam>
    /// <typeparam name="TRequest"></typeparam>
    /// <returns>Return generic response</returns>
    public async Task<TResponse> PostAsync<TResponse, TRequest>(string url, TRequest request)
    {
        var jsonString = JsonSerializer.Serialize(request);

        var content = new StringContent(jsonString, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

        var client = _httpClientFactory.CreateClient(ApiClientConstant.ObiletApiCLientName);

        HttpResponseMessage response = await client.PostAsync(url, content: content);

        var result = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<TResponse>(result);
    }
}