using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class DemoController : ControllerBase
{
    PlaceHolderClient _client;
    public DemoController(PlaceHolderClient client)
    {
        _client = client;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var items = await _client.GetTodoItem();

        Console.WriteLine(items);

        return Ok(items);
    }
}
