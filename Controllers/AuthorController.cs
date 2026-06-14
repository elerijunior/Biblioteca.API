using Biblioteca.API.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class AuthorController : ControllerBase
{
    private static List<Author> authors = new();

    [HttpGet]
    public List<Author> GetAuthor()
    {
        return authors;
    }

    [HttpPost]
    public string PostAuthor(string name)
    {
        Author author = Author.Create(name);
        authors.Add(author);

        return "Autor adicionado com sucesso!";
    }
    [HttpPut]
    public string PutAuthor(int id, string name) 
    {
        foreach (var author in authors)
        {
            if (author.Id == id)
            {
                author.ChangeName(name);
                return "Autor alterado com sucesso!";
            }
        }
        return "Autor não encontado!";
    }
    [HttpDelete]
    public string DeleteAuthor(int id)
    {
        Author searchAuthor = null;
        foreach (var author in authors)
        {
            if(author.Id == id) 
            {
                searchAuthor = author;
                break; 
            }        
        }
       
        if (searchAuthor == null)
        {
            return "Autor não encontrado!";
        }
        
        authors.Remove(searchAuthor);
        return "Autor removido com sucesso!";
    }
}