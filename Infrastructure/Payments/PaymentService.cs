using System.Text;
using Core.DTOs;
using Core.Services;
using Infrastructure.Persistence;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Payments
{
  public class PaymentService : IPaymentService
  {
    private readonly IMessageBusService _messageBusService;
    private const string QUEUE_NAME = "Payments";
    public PaymentService(IMessageBusService messageBusService)
    {
      // _httpClientFactory = httpClientFactory;
      // _paymentsBaseUrl = configuration.GetSection("Services:Payments").Value;
      _messageBusService = messageBusService;
    }
    public async void ProcessPayment(PaymentInfoDTO paymentInfoDTO)
    {
      var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);

      //http
      // var url = $"{_paymentsBaseUrl}/api/payments";
      // var paymentInfoContent = new StringContent(
      //   paymentInfoJson,
      //   Encoding.UTF8,
      //   "application/json"
      //   );

      // using (var httpClient = _httpClientFactory.CreateClient("Payments"))
      // {
      //   var response = await httpClient.PostAsync(url, paymentInfoContent);
      // }

      //message bus
      var paymentInfoBytes = Encoding.UTF8.GetBytes(paymentInfoJson);

      _messageBusService.Publish(QUEUE_NAME, paymentInfoBytes);
    }
  }
}