namespace Aquaculture.Contracts.Dto;

public record EditUserDto(
    Guid Id,
    string? FullName,
    string? Role,
    string? Email,
    string? Password);
