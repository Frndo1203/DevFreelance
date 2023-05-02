using Application.Queries.GetUser;

namespace UnitTests.Application.Queries
{
  public class GetUserQueryHandlerTests
  {
    [Fact]
    public async Task Handle_UserIsNotNull_ReturnsUserDetailsViewModel()
    {
      //Arrange
      var userRepositoryMock = new Mock<IUserRepository>();
      var user = new User("Test FullName", "test@test.com", DateTime.Now, "testPassword", "role");
      var request = new GetUserQuery(user.Id);

      userRepositoryMock.Setup(u => u.GetUserDetailsAsync(It.IsAny<int>())).ReturnsAsync(user);

      var handler = new GetUserQueryHandler(userRepositoryMock.Object);

      //Act
      var result = await handler.Handle(request, new CancellationToken());

      //Assert
      Assert.NotNull(result);
      Assert.Equal(result.FullName, user.FullName);
      Assert.Equal(result.Email, user.Email);
      Assert.Equal(result.BirthDate, user.BirthDate);

      userRepositoryMock.Verify(u => u.GetUserDetailsAsync(It.IsAny<int>()), Times.Once());


    }
  }
}