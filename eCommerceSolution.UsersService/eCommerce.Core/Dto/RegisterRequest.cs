namespace eCommerce.Core.Dto;

public record RegisterRequest(string? Email, string? Password, string? PersonName, EnumGender? Gender);