namespace Aquaculture.Contracts.Dto;

public record AuthenticationDto(
    Guid Id,
    string FullName,
    string Email,
    string Role,
    string Token);
