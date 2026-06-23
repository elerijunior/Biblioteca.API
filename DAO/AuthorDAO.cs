using Biblioteca.API.Entities;
using Npgsql;

namespace Biblioteca.API.DAO;

public class AuthorDAO
{
	private readonly string connectionString;

		public AuthorDAO(string connectionString)
		{
			this.connectionString = connectionString;
		}


		public void Add(Author author)
		{
			using var connection = new NpgsqlConnection(connectionString);
			
			connection.Open();
			
			string sql =
			@"INSERT INTO Authors (Name)
			VALUES (@name)";
			
			using var command = new NpgsqlCommand(sql, connection);

			command.Parameters.AddWithValue("@name", author.Name);

			command.ExecuteNonQuery();
		}
}