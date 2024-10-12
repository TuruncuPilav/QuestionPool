using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.Data.Entity;

public partial class MemberSetting
{
    public int Id { get; set; }

    public int? MemberId { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? LastEditedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? Role { get; set; }

    public string? Language { get; set; }
    [JsonIgnore]
    public virtual Member? Member { get; set; }
}
