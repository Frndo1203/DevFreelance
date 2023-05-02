
using Application.Commands.CreateProject;

namespace UnitTests.Application.Commands
{
  public class CreateProjectCommandHandlerTests
  {
    [Fact]
    public async Task InputDataIsOk_Executed_ReturnProjectId()
    {
      //Arrange
      var projectRepository = new Mock<IProjectRepository>();
      var unitOfWork = new Mock<IUnitOfWork>();

      var createProjectCommand = new CreateProjectCommand
      {
        Title = "Titulo de Teste",
        Description = "Uma descricao daora",
        TotalCost = 50000,
        IdClient = 1,
        IdFreelancer = 2
      };

      var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepository.Object, unitOfWork.Object);

      //Act
      var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());


      //Assert
      Assert.True(id >= 0);

      projectRepository.Verify(pr => pr.AddAsync(It.IsAny<Project>()), Times.Once());
      unitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once());
    }
  }
}