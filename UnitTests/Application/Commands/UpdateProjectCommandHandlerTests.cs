using Application.Commands.UpdateProject;

namespace UnitTests.Application.Commands
{
  public class UpdateProjectCommandHandlerTests
  {
    [Fact]
    public async Task Handle_ProjectExists_UpdatesProject()
    {
      //Arrange
      var projectRepositoryMock = new Mock<IProjectRepository>();
      var unitOfWorkMock = new Mock<IUnitOfWork>();
      var project = new Project("Test Title", "Test description", 1, 1, 10000);

      projectRepositoryMock.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(project);

      var request = new UpdateProjectCommand
      {
        Id = project.Id,
        Title = "Test Title 2",
        Description = "Test description 2",
        TotalCost = 20000
      };
      var handler = new UpdateProjectCommandHandler(projectRepositoryMock.Object, unitOfWorkMock.Object);

      //Act
      await handler.Handle(request, new CancellationToken());

      //Assert
      Assert.Equal("Test Title 2", project.Title);
      Assert.Equal("Test description 2", project.Description);
      Assert.Equal(20000, project.TotalCost);

      projectRepositoryMock.Verify(p => p.GetByIdAsync(It.IsAny<int>()), Times.Once());
      unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once());
    }
  }
}