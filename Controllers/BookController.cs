using Biblioteca.API.DAO;
using Biblioteca.API.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class BookController : ControllerBase
{

    private readonly BookDAO bookDAO;
    private static List<Book> books = new();

    public BookController(IConfiguration configuration)
    {
        string connectionString =
        configuration.GetConnectionString("DefaultConnection")
        ?? throw new Exception("Connection String não encontrada.");

        bookDAO = new BookDAO(connectionString);
    }

    [HttpGet]
    public List<Book> GetBooks()
    {
        List<Book> books = bookDAO.GetAll();
        return books;
    }

    [HttpPost]
    public string PostBooks(string title, int year)
    {
        Book livro = Book.Create(title, year);
        books.Add(livro);

        return "Livro criado com sucesso!";
    }

    [HttpPut]
    public string PutBooks(int id, string title, int year)
    {
        foreach (var book in books)
        {
            if (book.Id == id)
            {
                book.ChangeTitle(title);
                book.ChangeYear(year);
                return "Livro alterado com sucesso!";
            }    
        }
        return "Livro não existe na lista!";
    }

    [HttpDelete]
    public string DeleteBooks(int id) 
    {
        Book searchBook = null;
        foreach (var book in books)
        {
            if (book.Id == id)
            {
                searchBook = book;
                break;
            }
        }
        if (searchBook == null)
        {
            return "Livro não existe";
        }
        
        books.Remove(searchBook);
        return "Livro removido com sucesso!";
    }
}