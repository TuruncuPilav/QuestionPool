﻿using System;
using System.Collections.Generic;

namespace Core.Data.Entity;

public partial class QuestionType
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
