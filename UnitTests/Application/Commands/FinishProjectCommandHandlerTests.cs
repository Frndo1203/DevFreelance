using Application.Commands.FinishProject;

namespace UnitTests.Application.Commands
{
  public class FinishProjectCommandHandlerTests
  {
    [Fact]
    public async Task ProjectIsValid_Executed_ChangeProjectStatus()
    {
      //Arrange
      var projectRepositoryMock = new Mock<IProjectRepository>();
      var unitOfWorkMock = new Mock<IUnitOfWork>();
      var project = new Project("Test Title", "Test description", 1, 1, 10000);
      project.Start();

      projectRepositoryMock.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(project);

      var request = new FinishProjectCommand(project.Id);
      var handler = new FinishProjectCommandHandler(projectRepositoryMock.Object, unitOfWorkMock.Object);

      //Act
      await handler.Handle(request, new CancellationToken());

      //Assert
      Assert.True(project.Status == EProjectStatus.Finished);

      projectRepositoryMock.Verify(p => p.GetByIdAsync(It.IsAny<int>()), Times.Once());
      unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once());

    }
  }
}