using Application.Queries.GetAllProjects;

namespace UnitTests.Application.Queries
{
  public class GetAllProjectsCommandHandlerTests
  {
    [Fact]
    public async void ThreeProjectsExists_Executed_ReturnThreeProjectViewModels()
    {
      //Arrange
      var projects = new List<Project>
    {
    new Project("Nome do Teste", "Descricao de Teste 1", 1, 2, 10000),
    new Project("Nome do Teste 2", "Descricao de Teste 2", 1, 2, 20000),
    new Project("Nome do Teste 3", "Descricao de Teste 3", 1, 2, 30000)
    };

      var projectRepositoryMock = new Mock<IProjectRepository>();
      projectRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(projects);

      var getAllProjectsQuery = new GetAllProjectsQuery("");
      var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

      //Act
      var projectViewModelList = await getAllProjectsQueryHandler.Handle(
        getAllProjectsQuery,
        new CancellationToken());

      //Assert
      Assert.NotNull(projectViewModelList);
      Assert.NotEmpty(projectViewModelList);
      Assert.Equal(projects.Count, projectViewModelList.Count);

			projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
    }
  }
}