class CustomerController
{
    ctor(IMediator mediator)

    [Get]
    GetAllCustomer()
    {
        return mediator.Send(new GetAllCustomerQuery();
    }

    [Post]
    AddCustomer(CreateCustomerCmd objCustomer)
    {
        return mediator.Send(new CreateCustomerCmd())
    }

}

// interface ICommand : IRequest{};
// interface IQuery : IRequest{};


public record struct CreateCusotmerCommand : IRequest
{
    string Name;
}

public record AddCustomer : IRequest
{
    string Name;
}

class CreateCustomerHandler : IRequestHandler<CreateCusotmerCommand>
{
    ctor(CustomerService service)
    Handle(CreateCusotmerCommand command)
    {
        service.AddCustomer(CustomerService.Name);
    }
}