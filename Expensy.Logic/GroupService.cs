using Expensy.Logic.Interfaces;
using Expensy.Logic.Models;
using System;

namespace Expensy.Logic
{
    public class GroupService
    {
        private readonly IGroupRepository groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        public Group CreateGroup(string groupName)
        {
            if (GroupExists(groupName))
            {
                throw new ArgumentException("Group with the same name already exists");
            }

            return this.groupRepository.CreateGroup(groupName);
        }

        public void AddUserToGroup(int group_id, int user_id)
        {
            if (UserExistsInGroup(group_id, user_id))
            {
                throw new ArgumentException("User is already a member of the group");
            }

            this.groupRepository.AddUserToGroup(group_id, user_id);
        }

        private bool GroupExists(string groupName)
        {
            return this.groupRepository.GroupExists(groupName);
        }


        private bool UserExistsInGroup(int group_id, int user_id)
        {
            return this.groupRepository.UserExistsInGroup(group_id, user_id);
        }
    }
}
