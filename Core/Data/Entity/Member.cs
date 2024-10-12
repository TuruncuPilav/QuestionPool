using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.Data.Entity;

public partial class Member
{
    public Member()
    {
        Libraries = new HashSet<Library>();
        LibraryMembers = new HashSet<LibraryMember>();
        MemberSecurities = new HashSet<MemberSecurity>();
        MemberSettings = new HashSet<MemberSetting>();
        Questions = new HashSet<Question>();
    }
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? Gender { get; set; }

    public DateOnly? Birthday { get; set; }
    
    public virtual ICollection<Library> Libraries { get; set; } = new List<Library>();
    public virtual ICollection<LibraryMember> LibraryMembers { get; set; } = new List<LibraryMember>();
    
    public virtual ICollection<MemberSecurity> MemberSecurities { get; set; } = new List<MemberSecurity>();
    //[JsonInclude]
    public virtual ICollection<MemberSetting> MemberSettings { get; set; } = new List<MemberSetting>();
    
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
