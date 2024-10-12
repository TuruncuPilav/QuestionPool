using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.Data.Entity;

public partial class Question
{
    public int Id { get; set; }

    public int? MemberId { get; set; }

    public int? LibraryId { get; set; }

    public int? QuestionType { get; set; }

    public string? QuestionText { get; set; }

    public string? TrueAnswer { get; set; }

    public string? FalseAnswer2 { get; set; }

    public string? FalseAnswer3 { get; set; }

    public string? FalseAnswer4 { get; set; }

    public string? FalseAnswer5 { get; set; }

    public string? QuestionImg { get; set; }
    [JsonIgnore]
    public virtual Library? Library { get; set; }
    [JsonIgnore]
    public virtual Member? Member { get; set; }

    public virtual ICollection<QuestionSetting> QuestionSettings { get; set; } = new List<QuestionSetting>();
    [JsonIgnore]
    public virtual QuestionType? QuestionTypeNavigation { get; set; }
}
