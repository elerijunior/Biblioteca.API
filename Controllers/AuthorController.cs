using Biblioteca.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.API.DAO.Interface;
using Biblioteca.API.DAO;

[ApiController]
[Route("api/[controller]")]

public class AuthorController : ControllerBase
{
    private readonly IAuthorDAO _authorDAO;

    public AuthorController(IAuthorDAO authorDAO)
    {

        _authorDAO = authorDAO;
    }

    [HttpGet]
    public ActionResult<List<Author>>GetAuthor() 
    {
        List<Author> authors = _authorDAO.GetAll();
        return Ok(authors);
    }

    [HttpGet("{id}")]
    public ActionResult<List<Author>> GetById(int id)
    {
        Author? author = _authorDAO.GetById(id);
        if (author != null)
        {
            return Ok(author);
        }
        return NotFound("Autor não encontrado!");
    }

    [HttpPost]
    public IActionResult PostAuthor(string name)
    {
        Author author =  new Author(name);
        if (string.IsNullOrWhiteSpace(name)) 
        {
            return BadRequest();
        }
        _authorDAO.Add(author);
        return Ok(author);
    }

    [HttpPut]
    public string PutAuthor(int id, string name) 
    {
        Author? author = _authorDAO.GetById(id);
        if (author is null)
            return "Autor não encontado!";

        author.ChangeName(name);
        _authorDAO.Update(author);
        return "Autor Alterado com sucesso!";
    }

    [HttpDelete]
    public string DeleteAuthor(int id)
    {
        Author? author = _authorDAO.GetById(id);
        if(author != null)
        {
            _authorDAO.Delete(id);
            return "Autor deletado com sucesso!";
        }
        return "Autor não encontrado!";
    }
}