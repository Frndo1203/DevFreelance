using Application.Commands.FinishProject;
using Core.DTOs;

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
      var paymentServiceMock = new Mock<IPaymentService>();
      var project = new Project("Test Title", "Test description", 1, 1, 10000);
      project.Start();

      projectRepositoryMock.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(project);
      paymentServiceMock.Setup(p => p.ProcessPayment(It.IsAny<PaymentInfoDTO>())).ReturnsAsync(true);

      var request = new FinishProjectCommand
      {
        Id = project.Id,
        CreditCardNumber = "1234567899",
        Cvv = "123",
        ExpiresAt = "26/30",
        FullName = "Test FullName"
      };
      var handler = new FinishProjectCommandHandler(
        projectRepositoryMock.Object,
        unitOfWorkMock.Object,
        paymentServiceMock.Object);

      //Act
      await handler.Handle(request, new CancellationToken());

      //Assert
      Assert.True(project.Status == EProjectStatus.Finished);

      projectRepositoryMock.Verify(p => p.GetByIdAsync(It.IsAny<int>()), Times.Once());
      unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once());
      paymentServiceMock.Verify(p => p.ProcessPayment(It.IsAny<PaymentInfoDTO>()), Times.Once());

    }
  }
}