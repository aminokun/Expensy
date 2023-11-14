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
            RegisterService registerService = new RegisterService();

            // Act
            bool result = await registerService.Register("newUser", "new@user.nl", "password123");

            // Assert
            result.Should().BeTrue("because the registration should be successful");
        }

        [Fact]
        public async Task RegisterUser_ShouldReturnFalse_OnExistingUsername()
        {
            // Arrange
            RegisterService registerService = new RegisterService();

            // Act
            bool result = await registerService.Register("existingUser", "existing@user.nl", "password456");

            // Assert
            result.Should().BeFalse("because the username already exists");
        }
    }
}