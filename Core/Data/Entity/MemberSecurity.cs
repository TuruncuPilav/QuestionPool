using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.Data.Entity;

public partial class MemberSecurity
{
    public int Id { get; set; }

    public int? MemberId { get; set; }

    public string? Password { get; set; }
    [JsonIgnore]
    public virtual Member? Member { get; set; }
}
