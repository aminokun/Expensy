using MySql.Data.MySqlClient;
using Expensy.Data.DTO;
using Expensy.Logic.Interfaces;
using Expensy.Logic.Models;
using System.Data;

namespace Expensy.Data
{
    public class RegisterRepository : IRegisterRepository
    {
        string connectionString = "Server=192.168.178.27;port=3306;Database=Expensy;Uid=Scraper;Pwd=123Scraper21!;";

        public async Task CreateNewUser(User user)
        {
            using var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();
            var sql = "INSERT INTO Users (username, email, password) VALUES (@username, @email, @password)";
            var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@username", user.username);
            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.Parameters.AddWithValue("@password", user.password);

            await cmd.ExecuteNonQueryAsync();

        }
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            using var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            var sql = "SELECT * FROM Users WHERE email = @email";
            var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@email", email);

            using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new User
                {
                    user_id = reader.GetInt32("user_id"),
                    username = reader.GetString("username"),
                    email = reader.GetString("email"),
                    password = reader.GetString("password")
                };
            }

            return null;
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            using var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            var sql = "SELECT * FROM Users WHERE username = @username";
            var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@username", username);

            using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new User
                {
                    user_id = reader.GetInt32("user_id"),
                    username = reader.GetString("username"),
                    email = reader.GetString("email"),
                    password = reader.GetString("password")
                };
            }

            return null;
        }
    }
}
