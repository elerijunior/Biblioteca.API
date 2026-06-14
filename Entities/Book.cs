namespace Biblioteca.API.Entities;


public class Book
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public int Year { get; private set; }
    private static int nextId = 1;

    private Book()
    {

    }

    public static Book Create(string title, int year)
    {

        Book book = new Book();

        book.ChangeTitle(title);
        book.ChangeYear(year);
        book.Id = nextId++;
        return book;
    }


    public void ChangeTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("O Título é obrigatório.");
        }
        Title = title.Trim();
    }

    public void ChangeYear(int year)
    {
        if(year < 1450)
        {
            throw new ArgumentException("Ano inválido.");
        }
        Year = year;
    }
}