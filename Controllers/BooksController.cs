using Biblioteca.API.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class BooksController : ControllerBase
{
    private static List<Book> books = new();

    [HttpGet]
    public List<Book> GetBooks()
    {
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
        var searchBook;
        foreach (var book in books)
        {
            if (book.Id == id)
            {
                searchBook = book;
                searchBook.ChangeTitle(title);
                searchBook.ChangeYear(year);
                return searchBook;
            }
            else 
            {
                return "Livro não existe na lista!";
            }        
        }  
    }
    [HttpDelete]
    public string DeleteBooks(int id) 
    {
        var searchBook = Convert.ToInt32(Console.ReadLine());
        foreach(var book in books) 
        {
            if (book.Id != searchBook)
        }
    }
}   