namespace CqrsMediatRDemo.Domain
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }

        // parameterless constructor for EF
        private Customer() { }

        public Customer(Guid id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public void UpdateEmail(string email)
        {
            // simple validation
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty");

            Email = email;
        }
    }
}