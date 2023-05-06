using Core.DTOs;

namespace Core.Services
{
  public interface IPaymentService
  {
    void ProcessPayment(PaymentInfoDTO paymentInfoDTO);
  }
}