using Application.Commands.DeleteProject;

namespace UnitTests.Application.Commands
{
  public class DeleteProjectCommandHandlerTests
  {
    [Fact]
    public async Task InputDataIsOk_Executed_ChangeProjectStatus()
    {
      //arange
      var projectRepositoryMock = new Mock<IProjectRepository>();
      var unitOfWorkMock = new Mock<IUnitOfWork>();
      var project = new Project("Test Title", "Test description", 1, 1, 10000);
      project.Start();

      projectRepositoryMock.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(project);

      var request = new DeleteProjectCommand(project.Id);
      var handler = new DeleteProjectCommandHandler(projectRepositoryMock.Object, unitOfWorkMock.Object);

      //Act
      await handler.Handle(request, new CancellationToken());

      //Assert
      Assert.True(project.Status == EProjectStatus.Cancelled);

      projectRepositoryMock.Verify(p => p.GetByIdAsync(It.IsAny<int>()), Times.Once());
      unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once());

    }
  }
}