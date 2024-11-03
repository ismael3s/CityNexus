namespace CityNexus.People.Domain.Entities;

public sealed class People
{
    public Guid Id { get; private set; }

    public string FullName { get; private set; } = string.Empty;
    
    public string Cpf  { get; private set; } = string.Empty;
    
    public DateTime CreatedAt { get; private set; }
    
    public DateTime UpdatedAt { get; private set; }

    private People()
    {
    }

    public static People Create(string fullName, string cpf)
    {
        var people = new People
        {
            Id = Guid.NewGuid(),
            FullName = fullName.Trim(),
            Cpf = cpf.Trim()
        };
        return people;
    }
}