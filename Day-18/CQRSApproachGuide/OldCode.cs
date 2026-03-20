
class CustomerController
{
    ctor(CustomerService service)

    [Get]
    GetAllCustomer()
    {
        return service.GetAllCustomer();
    }

    [Post]
    AddCustomer(customer objCustomer)
    {
        return service.AddCustomer(objCustomer);
    }
}

class CustomerService
{
    GetAllCustomer
    AddCustomer
}

class CustomerDbContext
{
    GetAllCustomer();
    AddCustomer(customer objCustomer);
}
