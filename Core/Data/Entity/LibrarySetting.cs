using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.Data.Entity;

public partial class LibrarySetting
{
    public int Id { get; set; }

    public int? LibraryId { get; set; }

    public bool? Visibility { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastEditedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
    [JsonIgnore]
    public virtual Library? Library { get; set; }
}
