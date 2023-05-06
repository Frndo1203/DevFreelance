using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DTOs;
public record PaymentInfoDTO(
int IdProject,
string? CreditCardNumber,
string? Cvv,
string? ExpiresAt,
string? FullName,
decimal? Amount);