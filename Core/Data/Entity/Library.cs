using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Entity;

public partial class Library
{
    public int Id { get; set; }

    public int? MemberId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Category { get; set; }

    public virtual ICollection<LibraryMember> LibraryMembers { get; set; } = new List<LibraryMember>();

    public virtual ICollection<LibrarySetting> LibrarySettings { get; set; } = new List<LibrarySetting>();
    //[JsonIgnore]
    public virtual Member? Member { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
