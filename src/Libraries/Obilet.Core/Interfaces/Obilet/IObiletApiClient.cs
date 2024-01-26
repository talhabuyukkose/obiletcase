namespace Obilet.Core.Interfaces;

public interface IObiletApiClient
{
    /// <summary>
    /// Post a request to OBiletApi
    /// </summary>
    /// <param name="url"></param>
    /// <param name="request"></param>
    /// <typeparam name="TResponse"></typeparam>
    /// <typeparam name="TRequest"></typeparam>
    /// <returns>Return generic response</returns>
    Task<TResponse> PostAsync<TResponse, TRequest>(string url, TRequest request);
}