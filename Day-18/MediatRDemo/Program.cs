
﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var services = new ServiceCollection();

services.AddLogging();

services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Light).Assembly));

services.AddScoped<Light>();

services.AddScoped<RemoteControl>();

var provider = services.BuildServiceProvider();

var remote = provider.GetService<RemoteControl>();

remote.PressButton();

public class Light
{
    public void On()
    {
        Console.WriteLine("Light is on");
    }
}

public class LightOnCommand : IRequest
{
    public Light Light { get; set; }
}

public class LightOnHandler : IRequestHandler<LightOnCommand>
{
    public Task Handle(LightOnCommand request, CancellationToken cancellationToken)
    {
        request.Light.On();
        return Task.CompletedTask;
    }
}

public class RemoteControl
{
    IMediator _mediator;
    public RemoteControl(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void PressButton()
    {
        _mediator.Send(new LightOnCommand() { Light = new Light() });
        // _mediator.Publish();
    }
}
