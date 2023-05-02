using Application.Commands.CreateComment;

namespace UnitTests.Application.Commands
{
  public class CreateCommentCommandHandlerTests
  {
    [Fact]
    public async Task InputDataIsOk_Executed_MethodsCorrectlyCalled()
    {
      //Arrange
      var projectRepository = new Mock<IProjectRepository>();
      var unitOfWork = new Mock<IUnitOfWork>();

      var createCommentCommand = new CreateCommentCommand
      {
        Content = "Random project comment",
        IdProject = 1,
        IdUser = 1
      };

      //Act
      var createCommentCommandHandler = new CreateCommentCommandHandler(projectRepository.Object, unitOfWork.Object);

      //Assert
      await createCommentCommandHandler.Handle(createCommentCommand, new CancellationToken());

      projectRepository.Verify(pr => pr.AddCommentAsync(It.IsAny<ProjectComment>()), Times.Once());
      unitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once());
    }
  }
}