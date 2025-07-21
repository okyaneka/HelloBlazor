using System.Text.Json.Serialization;

namespace HelloBlazor.App.Features.Trainer.Models;

public class TrainerItem
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("company")]
    public required Company Company { get; set; }

    [JsonPropertyName("company_user")]
    public required CompanyUser CompanyUser { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("class_type")]
    public required int ClassType { get; set; }

    [JsonPropertyName("program_benefits")]
    public required string ProgramBenefits { get; set; }

    [JsonPropertyName("learning_targets")]
    public required LearningTargets LearningTargets { get; set; }

    [JsonPropertyName("program_information")]
    public required ProgramInformation ProgramInformation { get; set; }

    [JsonPropertyName("fasilitator")]
    public required List<Facilitator> Facilitators { get; set; }

    [JsonPropertyName("trainers")]
    public required List<Trainer> Trainers { get; set; }

    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("is_free")]
    public required bool IsFree { get; set; }

    [JsonPropertyName("is_prakerja")]
    public required bool IsPrakerja { get; set; }

    [JsonPropertyName("total_participants")]
    public required int TotalParticipants { get; set; }

    [JsonPropertyName("estimation_duration")]
    public required EstimationDuration EstimationDuration { get; set; }

    [JsonPropertyName("review")]
    public required Review Review { get; set; }

    [JsonPropertyName("duplicate")]
    public required Duplicate Duplicate { get; set; }

    [JsonPropertyName("published_at")]
    public required DateTime PublishedAt { get; set; }

    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }
}

public class Company
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("email")]
    public required string Email { get; set; }
}

public class CompanyUser
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("email")]
    public required string Email { get; set; }
}

public class LearningTargets
{
    [JsonPropertyName("studies")]
    public required Studies Studies { get; set; }

    [JsonPropertyName("competence")]
    public required List<string> Competence { get; set; }
}

public class Studies
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }
}

public class ProgramInformation
{
    [JsonPropertyName("cover")]
    public required Cover Cover { get; set; }

    [JsonPropertyName("discount_price")]
    public required int DiscountPrice { get; set; }

    [JsonPropertyName("selling_price")]
    public required int SellingPrice { get; set; }

    [JsonPropertyName("selling_link")]
    public required List<SellingLink> SellingLink { get; set; }
}

public class Cover
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }
}

public class SellingLink
{
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }
}

public class Facilitator
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("description")]
    public required string Description { get; set; }

    [JsonPropertyName("picture")]
    public required Picture Picture { get; set; }
}

public class Picture
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }
}

public class Trainer
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("gender")]
    public required Gender Gender { get; set; }

    [JsonPropertyName("email")]
    public required string Email { get; set; }

    [JsonPropertyName("fullname")]
    public required string Fullname { get; set; }

    [JsonPropertyName("phone_number")]
    public required string PhoneNumber { get; set; }
}

public class Gender
{
    [JsonPropertyName("text")]
    public required string Text { get; set; }

    [JsonPropertyName("value")]
    public required int Value { get; set; }
}

public class EstimationDuration
{
    [JsonPropertyName("hour")]
    public required int Hour { get; set; }

    [JsonPropertyName("minute")]
    public required int Minute { get; set; }

    [JsonPropertyName("second")]
    public required int Second { get; set; }
}

public class Review
{
    [JsonPropertyName("rating")]
    public double? Rating { get; set; }

    [JsonPropertyName("total")]
    public required int Total { get; set; }

    [JsonPropertyName("total_star_calculation")]
    public required int TotalStarCalculation { get; set; }

    [JsonPropertyName("star")]
    public required Star Star { get; set; }
}

public class Star
{
    [JsonPropertyName("one")]
    public required int One { get; set; }

    [JsonPropertyName("two")]
    public required int Two { get; set; }

    [JsonPropertyName("three")]
    public required int Three { get; set; }

    [JsonPropertyName("four")]
    public required int Four { get; set; }

    [JsonPropertyName("five")]
    public required int Five { get; set; }
}

public class Duplicate
{
    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("message")]
    public required string Message { get; set; }
}

public class CompanyItem
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("description")]
    public required string Description { get; set; }

    [JsonPropertyName("logo_url")]
    public required string LogoUrl { get; set; }

    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }
}