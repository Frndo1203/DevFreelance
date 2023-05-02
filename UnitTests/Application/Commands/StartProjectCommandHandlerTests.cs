

using Application.Commands.StartProject;

namespace UnitTests.Application.Commands
{
  public class StartProjectCommandHandlerTests
  {
    [Fact]
    public async Task Handle_ProjectExists_StartsTheProject()
    {
      //Arrange
      var projectRepositoryMock = new Mock<IProjectRepository>();
      var unitOfWorkMock = new Mock<IUnitOfWork>();
      var project = new Project("Test Title", "Test description", 1, 1, 10000);

      projectRepositoryMock.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(project);

      var request = new StartProjectCommand(project.Id);
      var handler = new StartProjectCommandHandler(projectRepositoryMock.Object, unitOfWorkMock.Object);

      //Act
      await handler.Handle(request, new CancellationToken());

      //Assert
      Assert.True(project.Status == EProjectStatus.InProgress);

      projectRepositoryMock.Verify(p => p.GetByIdAsync(It.IsAny<int>()), Times.Once());
      unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once());

    }
  }
}