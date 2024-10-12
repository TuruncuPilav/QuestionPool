using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.Data.Entity;

public partial class LibraryMember
{
    public int Id { get; set; }

    public int? LibraryId { get; set; }

    public int? MemberId { get; set; }

    public string? Role { get; set; }

    public DateTime? AddedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
    [JsonIgnore]
    public virtual Library? Library { get; set; }
    [JsonIgnore]
    public virtual Member? Member { get; set; }
}
