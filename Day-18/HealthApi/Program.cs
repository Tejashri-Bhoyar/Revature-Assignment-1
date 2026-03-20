
[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        // DbCOntext

        var watch = new Watch();

        watch.Start();
        // SELECT TOP 100 * FORM Customrs;
        watch.Stop();

        var DatabaseReadTimeInMilliseconds = watch.ElapsedTime();

        var httpClient = new HttpClient();

        watch.Start();

        var customers = httpClient.GetAsync("http://localhost:5000/api/v1/customers");

        var CustomerServiceStatus = customers.IsCompletedSuccessfully;



        watch.Stop();

        var CustomerReadTimeInMilliseconds = watch.ElapsedTime;


        var response = new HealthDTO
        {
            DatabaseStatus = true,
            DatabaseReadTimeInMilliseconds = DatabaseReadTimeInMilliseconds,
            CustomerServiceStatus = CustomerServiceStatus,
            CustomerReadTimeInMilliseconds = CustomerReadTimeInMilliseconds
        };

        return Ok(response);

    }
}

public class HealthDTO
{
    public bool DatabaseStatus { get; set; }
    public int DatabaseReadTimeInMilliseconds { get; set; }

    public bool CustomerServiceStatus { get; set; }
    public int CustomerReadTimeInMilliseconds { get; set; }


}