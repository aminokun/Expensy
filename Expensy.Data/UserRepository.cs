using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Expensy.Data.DTO;

namespace Expensy.Data
{
    public class UserRepository
    {
        string connectionString = "Server=192.168.178.27;port=3306;Database=Expensy;Uid=Scraper;Pwd=123Scraper21!;";

        public async Task CreateNewUser(UserDTO user)
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

    }
}
