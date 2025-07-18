using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HelloBlazor.App.Features.Auth.Models;

public class AuthModel
{

}

public class LoginModel
{
  [Required(ErrorMessage = "Email is required.")]
  public string? Email { get; set; }

  [Required(ErrorMessage = "Password is required.")]
  public string? Password { get; set; }
}

public class LoginData
{
  [JsonPropertyName("id")]
  public required string Id { get; set; }

  [JsonPropertyName("email")]
  public required string Email { get; set; }

  [JsonPropertyName("phone_number")]
  public required string PhoneNumber { get; set; }

  [JsonPropertyName("fullname")]
  public required string Fullname { get; set; }

  [JsonPropertyName("token")]
  public required string Token { get; set; }
}

public class LoginResponse : DefaultResponse<LoginData>
{ }