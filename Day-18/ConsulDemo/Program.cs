using Consul;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(cfg =>
{
    cfg.Address = new Uri("http://localhost:8500");
}));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

var consulClient = app.Services.GetRequiredService<IConsulClient>();

var registration = new AgentServiceRegistration()
{
    ID = $"order-service-{Guid.NewGuid()}",
    Name = "order-service",
    Address = "localhost",
    Port = 7000
};

await consulClient.Agent.ServiceRegister(registration);

app.Lifetime.ApplicationStopping.Register(() =>
{
    consulClient.Agent.ServiceDeregister(registration.ID).Wait();
});

app.Run();