namespace Aquaculture.Contracts.Dto;

public record UserDto(
    Guid Id,
    string FullName,
    string Role,
    string Email,
    string Password);
