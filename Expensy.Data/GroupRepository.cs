using Expensy.Logic.Interfaces;
using Expensy.Logic.Models;
using MySql.Data.MySqlClient;

namespace Expensy.Data
{
    public class GroupRepository : IGroupRepository
    {
        string connectionString = "Server=192.168.178.27;port=3306;Database=Expensy;Uid=Scraper;Pwd=123Scraper21!;";
        public Group CreateGroup(string groupName)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var sql = "INSERT INTO ExpenseGroups (groupName) VALUES (@groupName)";
            var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@groupName", groupName);
            cmd.ExecuteNonQuery();

            var group_id = (int)cmd.LastInsertedId;
            return new Group { Group_Id = group_id, GroupName = groupName };
        }
        public void AddUserToGroup(int group_id, int user_id)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            var sql = "INSERT INTO ExpenseGroupUsers (group_id, user_id) VALUES (@group_id, @user_id)";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@group_id", group_id);
            cmd.Parameters.AddWithValue("@user_id", user_id);
            cmd.ExecuteNonQuery();
        }

        public bool GroupExists(string groupName)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            var sql = "SELECT COUNT(*) FROM ExpenseGroups WHERE groupName = @groupName";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@groupName", groupName);

            var count = (long)cmd.ExecuteScalar();
            return count > 0;
        }

        public bool UserExistsInGroup(int group_id, int user_id)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            var sql = "SELECT COUNT(*) FROM ExpenseGroupUsers WHERE group_id = @group_id AND user_id = @user_id";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@group_id", group_id);
            cmd.Parameters.AddWithValue("@user_id", user_id);

            var count = (long)cmd.ExecuteScalar();
            return count > 0;
        }
    }
}
