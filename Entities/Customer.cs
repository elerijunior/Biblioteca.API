namespace Biblioteca.API.Entities;


public class Customer
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    private static int nextId = 1;
    private Customer()
    {

    }

    public static Customer Create(string name, string email)
    {
        Customer customer  = new Customer();
        customer.ChangeName(name);
        customer.ChangeEmail(email);
        customer.Id = nextId++;
        return customer;
    }

    public void ChangeName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Nome inválido.");
        }
        Name = name.Trim();
    }

    public void ChangeEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
        {
            throw new ArgumentException("Email inválido.");
        }
        Email = email.Trim();
    }
}