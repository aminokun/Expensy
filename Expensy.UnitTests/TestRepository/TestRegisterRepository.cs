using Expensy.Logic.Interfaces;
using Expensy.Logic.Models;
using Expensy.UnitTests.TestModels;
using FluentAssertions;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace Expensy.UnitTests.TestRepository
{
    public class TestRegisterRepository : IRegisterRepository
    {
        public async Task CreateNewUser(User user)
        {
            user.Should().NotBeNull();
            user.username.Should().NotBeNullOrEmpty();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            TestUser testUser = new TestUser ("existingUser", "existing@user.nl", "password456");

            if(email == "existing@user.nl")
            {
                return new User
                {
                    username = testUser.username,
                    email = testUser.email,
                    password = testUser.password,
                };
            }

            return null;
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            TestUser testUser = new TestUser("existingUser", "existing@user.nl", "password456");

            if (username == "existingUser")
            {
                return new User
                {
                    username = testUser.username,
                    email = testUser.email,
                    password = testUser.password,
                };
            }
            return null;
        }
    }
}
