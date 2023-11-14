using Xunit;
using FluentAssertions;
using Expensy.Logic;

namespace Expensy.UnitTests
{
    public class RegisterServiceTests
    {
        [Fact]
        public async Task RegisterUser_ShouldReturnTrue_OnSuccessfulRegistration()
        {
            // Arrange
            var registerService = new RegisterService();

            // Act
            bool result = await registerService.Register("newUser", "new@user.nl", "password123");

            // Assert
            result.Should().BeTrue("because the registration should be successful");
        }

        [Fact]
        public async Task RegisterUser_ShouldReturnFalse_OnExistingUsername()
        {
            // Arrange
            var userService = new RegisterService();

            // Act
            bool result = await userService.Register("existingUser", "existing@user.nl", "password456");

            // Assert
            result.Should().BeFalse("because the username already exists");
        }
    }
}