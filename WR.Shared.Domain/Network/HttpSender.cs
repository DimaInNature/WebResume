namespace WR.Shared.Domain.Network;

public class HttpSender
{
    private readonly string _hostUri;

    public HttpSender(string hostUri) => _hostUri = hostUri ?? throw new ArgumentNullException();

    #region Get

    public async Task<TResponse?> GetAsync<TResponse>()
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(requestUri: $"{_hostUri}/");

        return await Deserialize<TResponse>(responseMessage: response);
    }

    public async Task<TResponse?> GetAsync<TResponse>(CancellationToken cancellationToken)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(requestUri: $"{_hostUri}/", cancellationToken);

        return await Deserialize<TResponse>(responseMessage: response);
    }

    public async Task<TResponse?> GetAsync<TResponse>(string routePath)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(requestUri: $"{_hostUri}/{routePath}");

        return await Deserialize<TResponse>(responseMessage: response);
    }

    public async Task<TResponse?> GetAsync<TResponse>(string routePath, CancellationToken cancellationToken)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(requestUri: $"{_hostUri}/{routePath}", cancellationToken);

        return await Deserialize<TResponse>(responseMessage: response);
    }

    #endregion

    #region Post

    public async Task PostAsync<TRequest>(string routePath,
        TRequest serializableObj)
    {
        using var httpClient = new HttpClient();

        await httpClient.PostAsync(
            requestUri: $"{_hostUri}/{routePath}",
            content: new StringContent(
                content: Serialize(obj: serializableObj),
                encoding: Encoding.UTF8,
                mediaType: "application/json"));
    }

    public async Task PostAsync<TRequest>(string routePath,
       TRequest serializableObj, CancellationToken cancellationToken)
    {
        using var httpClient = new HttpClient();

        await httpClient.PostAsync(
            requestUri: $"{_hostUri}/{routePath}",
            content: new StringContent(
                content: Serialize(obj: serializableObj),
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: cancellationToken);
    }

    public async Task<TResponse?> PostAndReturnAsync<TRequest, TResponse>(
        string routePath, TRequest serializableObj,
        CancellationToken cancellationToken)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.PostAsync(
            requestUri: $"{_hostUri}/{routePath}",
           content: new StringContent(
                content: Serialize(obj: serializableObj),
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
        cancellationToken: cancellationToken);

        return await Deserialize<TResponse>(responseMessage: response);
    }

    public async Task<T?> PostAndReturnAsync<T>(
        string routePath, T serializableObj,
        CancellationToken cancellationToken)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.PostAsync(
            requestUri: $"{_hostUri}/{routePath}",
           content: new StringContent(
                content: Serialize(obj: serializableObj),
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
        cancellationToken: cancellationToken);

        return await Deserialize<T>(responseMessage: response);
    }

    public async Task<TResponse?> PostAndReturnAsync<TResponse, TRequest>(
        string routePath, TRequest serializableObj,
        CancellationToken cancellationToken)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.PostAsync(
            requestUri: $"{_hostUri}/{routePath}",
           content: new StringContent(
                content: Serialize(obj: serializableObj),
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
        cancellationToken: cancellationToken);

        if (typeof(TResponse) == typeof(string))
        {
            string strRequest = await response.Content.ReadAsStringAsync(cancellationToken);

            return (TResponse)(object)strRequest;
        }
            
        return await Deserialize<TResponse>(responseMessage: response);
    }

    #endregion

    #region Put

    public async Task PutAsync<TRequest>(string routePath,
        TRequest serializableObj)
    {
        using var httpClient = new HttpClient();

        await httpClient.PutAsync(
            requestUri: $"{_hostUri}/{routePath}",
            content: new StringContent(
                content: Serialize(obj: serializableObj),
                encoding: Encoding.UTF8,
                mediaType: "application/json"));
    }

    public async Task PutAsync<TRequest>(string routePath,
       TRequest serializableObj, CancellationToken cancellationToken)
    {
        using var httpClient = new HttpClient();

        await httpClient.PutAsync(
            requestUri: $"{_hostUri}/{routePath}",
            content: new StringContent(
                content: Serialize(obj: serializableObj),
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: cancellationToken);
    }

    #endregion

    #region Delete

    public async Task DeleteAsync(string routePath)
    {
        using var httpClient = new HttpClient();

        await httpClient.DeleteAsync(requestUri: $"{_hostUri}/{routePath}");
    }

    public async Task DeleteAsync(string routePath,
        CancellationToken cancellationToken)
    {
        using var httpClient = new HttpClient();

        await httpClient.DeleteAsync(requestUri: $"{_hostUri}/{routePath}",
            cancellationToken: cancellationToken);
    }

    #endregion

    private string Serialize<T>(T obj) => JsonConvert.SerializeObject(value: obj);

    private async Task<T?> Deserialize<T>(HttpResponseMessage responseMessage)
    {
        string apiResponse = await responseMessage.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<T>(value: apiResponse);
    }
}