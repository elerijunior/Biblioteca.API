using Biblioteca.API.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class CustomerController : ControllerBase
{
    private static List<Customer> customers = new();

    [HttpGet]
    public List<Customer> GetCustomer() 
    {
        return customers;
    }

    [HttpPost]
    public string PostCostumer(string name, string email)
    {
        Customer customer = Customer.Create(name, email);
        customers.Add(customer);
        return "Cliente adicionado com sucesso!";
    }

    [HttpPut]
    public string PutCustomer(int id, string name, string email)
    {
        foreach(var customer in customers) 
        { 
            if(customer.Id == id) 
            {
                customer.ChangeName(name);
                customer.ChangeEmail(email);
                return "Cliente alterado com sucesso!";
            }
        }
        return "Cliente não encontrado!";
    }

    [HttpDelete]
    public string DeleteCustomer(int id)
    {
        Customer searchCustomer = null;
        foreach (var customer in customers)
        {
            if(customer.Id == id) 
            { 
                searchCustomer = customer;
                break;
            }
        }
        if(searchCustomer == null)
        {
            return "Cliente não encontrado na lista";
        }
        customers.Remove(searchCustomer);
        return "Cliente removido com sucesso!";
    }
}
