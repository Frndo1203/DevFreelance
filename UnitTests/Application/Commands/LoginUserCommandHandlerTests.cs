using Application.Commands.LoginUser;

namespace UnitTests.Application.Commands;

public class LoginUserCommandHandlerTests
{
  [Fact]
  public async Task ValidLoginData_WhenUserIsFind_ReturnsLoginUserViewModel()
  {
    //Arrange
    var userRepositoryMock = new Mock<IUserRepository>();
    var authServiceMock = new Mock<IAuthService>();

    var request = new LoginUserCommand
    {
      Email = "test@example.com",
      Password = "TestPassword"
    };
    var user = new User("TestName", "test@example.com", new DateTime(2000, 1, 1), "HashedPassword", "role");
    var handler = new LoginUserCommandHandler(userRepositoryMock.Object, authServiceMock.Object);

    authServiceMock.Setup(a => a.ComputeSha256Hash("TestPassword")).Returns("HashedPassword");
    authServiceMock.Setup(a => a.GenerateJwtToken("test@example.com", "role")).Returns("token");
    userRepositoryMock.Setup(u => u.GetUserByEmailAndPasswordAsync("test@example.com", "HashedPassword")).ReturnsAsync(user);

    //Act
    var result = await handler.Handle(request, new CancellationToken());

    //Assert
    Assert.NotNull(result);
    Assert.Equal("token", result.Token);
    Assert.Equal("test@example.com", result.Email);

    authServiceMock.Verify(a => a.ComputeSha256Hash("TestPassword"), Times.Once());
    authServiceMock.Verify(a => a.GenerateJwtToken("test@example.com", "role"), Times.Once());
    userRepositoryMock.Setup(u => u.GetUserByEmailAndPasswordAsync("test@example.com", "HashedPassword")).ReturnsAsync(user);
  }

  [Fact]
  public async Task ValidLoginData_UserIsNotFound_ReturnsNull()
  {
    //Arrange
    var userRepositoryMock = new Mock<IUserRepository>();
    var authServiceMock = new Mock<IAuthService>();

    var request = new LoginUserCommand
    {
      Email = "Test@gmail.com",
      Password = "TestPassword"
    };

    User? user = null;
    var handler = new LoginUserCommandHandler(userRepositoryMock.Object, authServiceMock.Object);

    authServiceMock.Setup(a => a.ComputeSha256Hash("TestPassword")).Returns("HashedPassword");
    userRepositoryMock.Setup(u => u.GetUserByEmailAndPasswordAsync("Test@gmail.com", "HashedPassword")).ReturnsAsync(user);

    //Act
    var result = await handler.Handle(request, new CancellationToken());

    //Assert
    Assert.Null(result);

    authServiceMock.Verify(a => a.ComputeSha256Hash("TestPassword"), Times.Once());
    userRepositoryMock.Verify(u => u.GetUserByEmailAndPasswordAsync("Test@gmail.com", "HashedPassword"), Times.Once());
  }

}
