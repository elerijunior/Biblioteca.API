using Biblioteca.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.API.DAO;

[ApiController]
[Route("api/[controller]")]

public class AuthorController : ControllerBase
{
    private readonly AuthorDAO authorDAO;

    public AuthorController(IConfiguration configuration)
    {
        string connectionString =
        configuration.GetConnectionString("DefaultConnection")
        ?? throw new Exception("Connection String não encontrada.");

        authorDAO = new AuthorDAO(connectionString);
    }

    [HttpGet]
    public List<Author> GetAuthor()
    {
        
        List<Author> authors = authorDAO.GetAll();
        return authors;
    }

    [HttpPost]
    public string PostAuthor(string name)
    {
        Author author = Author.Create(name);
        authorDAO.Add(author);

        return "Autor adicionado com sucesso!";
    }
    [HttpPut]
    public string PutAuthor(int id, string name) 
    {
        Author? author = authorDAO.GetById(id);
        if (author != null)
        {
            author.ChangeName(name);
            authorDAO.Update(author);
            return "Autor Alterado com sucesso!";
        }
        return "Autor não encontado!";
    }
    [HttpDelete]
    public string DeleteAuthor(int id)
    {
        Author? author = authorDAO.GetById(id);
        if(author != null)
        {
            authorDAO.Delete(id);
            return "Autor deletado com sucesso!";
        }
        return "Autor não encontrado!";
    }
}