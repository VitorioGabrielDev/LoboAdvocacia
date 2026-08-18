namespace Lobo.Domain.SharedContext.Entities;

public class Customer : Entity
{
    public string FirstName { get; private set; } = string.Empty;
    public string FullName { get; private set; } = string.Empty;
    public string NationalId { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string ContactPhone { get; private set; } = string.Empty;
    public string Partner { get; private set; } = string.Empty;
    public string Neighborhood { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string State { get; private set; } = string.Empty;
    
    private Customer() { }

    public Customer(string firstName, string fullName, string nationalId, string email, string contactPhone, string partner, string neighborhood)
    {
        FirstName = firstName;
        FullName = fullName;
        NationalId = nationalId;
        Email = email;
        ContactPhone = contactPhone;
        Partner = partner;
        Neighborhood = neighborhood;
        City = neighborhood;
        State = neighborhood;
    }
}