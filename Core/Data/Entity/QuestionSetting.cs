using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.Data.Entity;

public partial class QuestionSetting
{
    public int Id { get; set; }

    public int? QuestionId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastEditedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
    [JsonIgnore]
    public virtual Question? Question { get; set; }
}
