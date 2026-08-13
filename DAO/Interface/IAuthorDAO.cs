using Biblioteca.API.Entities;
using Biblioteca.API.DAO;

namespace Biblioteca.API.DAO.Interface;

public interface IAuthorDAO
{
    public List<Author> GetAll();
    public void Add(Author author);
    public Author? GetById(int _id);
    public void Update(Author author);
    public void Delete(int id);
}