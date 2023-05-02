using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Queries.GetProjectById;

namespace UnitTests.Application.Queries
{
  public class GetProjectByIdHandlerTests
  {
    [Fact]
    public async Task Handle_ProjectIsNotNull_ReturnsProjectDetailViewModel()
    {
      //Arrange
      var projectRepositoryMock = new Mock<IProjectRepository>();
      var project = new Project("Test Title", "Test Description", 1, 1, 10000);
      var request = new GetProjectByIdQuery(project.Id);

      projectRepositoryMock.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(project);

      var handler = new GetProjectByIdQueryHandler(projectRepositoryMock.Object);

      //Act
      var result = await handler.Handle(request, new CancellationToken());

      //Assert
      Assert.NotNull(result);
      Assert.Equal(result.Id, project.Id);
      Assert.Equal(result.Title, project.Title);
      Assert.Equal(result.Description, project.Description);
      Assert.Equal(result.TotalCost, project.TotalCost);

      projectRepositoryMock.Verify(s => s.GetByIdAsync(It.IsAny<int>()), Times.Once());
    }
  }
}