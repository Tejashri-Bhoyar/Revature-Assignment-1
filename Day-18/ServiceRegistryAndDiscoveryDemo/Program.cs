// Consul - Registry and Discovery
var serviceRegistry = new Dictionary<string, string>();
// Registry
serviceRegistry.Add("CustomerService", "http://localhost:5000");
var httpClient = new HttpClient();
// Disovery
var customerServiceUrl = serviceRegistry["CustomerService"];
var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts/1");
Console.WriteLine($"Is Success: {response.IsSuccessStatusCode}");
Console.WriteLine($"Content: {await response.Content.ReadAsStringAsync()}");
