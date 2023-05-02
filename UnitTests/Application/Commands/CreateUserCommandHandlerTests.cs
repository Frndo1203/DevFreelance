using Application.Commands.CreateUser;

namespace UnitTests.Application.Commands
{
  public class CreateUserCommandHandlerTests
  {
    [Fact]
    public async Task InputDataIsOk_Executed_ReturnUserId()
    {
      //Arrange
      var userRepositoryMock = new Mock<IUserRepository>();
      var unitOfWorkMock = new Mock<IUnitOfWork>();
      var authServiceMock = new Mock<IAuthService>();
      authServiceMock.Setup(a => a.ComputeSha256Hash(It.IsAny<string>())).Returns("R@ndOmP@ssw0rd");

      var request = new CreateUserCommand
      {
        FullName = "Test User",
        Email = "test@example.com",
        BirthDate = new DateTime(2000, 1, 1),
        Password = "password",
        Role = "user"
      };

      var createUserCommandHandler = new CreateUserCommandHandler(userRepositoryMock.Object, unitOfWorkMock.Object, authServiceMock.Object);

      //Act
      var userId = await createUserCommandHandler.Handle(request, new CancellationToken());

      //Assert
      Assert.True(userId >= 0);

      userRepositoryMock.Verify(r => r.AddAsync(It.Is<User>(u => u.FullName == request.FullName
        && u.Email == request.Email
        && u.BirthDate == request.BirthDate
        && u.Password == "R@ndOmP@ssw0rd"
        && u.Role == request.Role)), Times.Once);
      unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once());
      authServiceMock.Verify(a => a.ComputeSha256Hash(It.IsAny<string>()), Times.Once());
    }
  }
}