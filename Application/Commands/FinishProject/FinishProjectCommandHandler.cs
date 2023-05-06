using Microsoft.VisualBasic.CompilerServices;
using Core.DTOs;
using Core.Repositories;
using Core.Services;
using MediatR;

namespace Application.Commands.FinishProject
{
  public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
  {
    private readonly IPaymentService _paymentService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProjectRepository _projectRepository;
    public FinishProjectCommandHandler(
      IProjectRepository projectRepository,
      IUnitOfWork unitOfWork,
      IPaymentService paymentService)
    {
      _projectRepository = projectRepository;
      _unitOfWork = unitOfWork;
      _paymentService = paymentService;
    }
    public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
    {
      var project = await _projectRepository.GetByIdAsync(request.Id);

      var paymentInfoDTO = new PaymentInfoDTO(
        request.Id,
        request.CreditCardNumber,
        request.Cvv,
        request.ExpiresAt,
        request.FullName,
        project?.TotalCost);

      _paymentService.ProcessPayment(paymentInfoDTO);
      project?.SetPaymentPending();

      await _unitOfWork.SaveChangesAsync();

      return Unit.Value;
    }
  }
}