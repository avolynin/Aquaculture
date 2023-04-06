using System.Net.Mail;

namespace Aquaculture.Contracts.Dto;
public record LoginDto(string Email, string Password);
