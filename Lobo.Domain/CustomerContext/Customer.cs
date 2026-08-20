using Lobo.Domain.SharedContext.Entities;

namespace Lobo.Domain.CustomerContext;

public class Customer : Entity
{
    public string FirstName { get; private set; } = string.Empty;
    public string FullName { get; private set; } = string.Empty;
    public string NationalId { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string ContactPhone { get; private set; } = string.Empty;
    public string Neighborhood { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string State { get; private set; } = string.Empty;
    
    private Customer() { }

    public Customer(string firstName, string fullName, string nationalId, string email, string contactPhone, string neighborhood, string city, string state)
    {
        FirstName = firstName;
        FullName = fullName;
        NationalId = nationalId;
        Email = email;
        ContactPhone = contactPhone;
        Neighborhood = neighborhood;
        City = city;
        State = state;
    }

    public void Update(string firstName, string fullName, string nationalId, string email, string contactPhone, string neighborhood, string city, string state)
    {
        FirstName = firstName;
        FullName = fullName;
        NationalId = nationalId;
        Email = email;
        ContactPhone = contactPhone;
        Neighborhood = neighborhood;
        City = city;
        State = state;
    }
}