public class PlaceHolderClient
{
    private readonly HttpClient _http;

    public PlaceHolderClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<string> GetTodoItem()
    {
        var response = await _http.GetAsync($"/todos/1");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}