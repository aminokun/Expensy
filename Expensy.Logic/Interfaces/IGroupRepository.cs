using Expensy.Logic.Models;

namespace Expensy.Logic.Interfaces
{
    public interface IGroupRepository
    {
        Group CreateGroup(string groupName);
        void AddUserToGroup(int group_id, int user_id);
        public bool GroupExists(string groupName);
        public bool UserExistsInGroup(int group_id, int user_id);
    }
}
