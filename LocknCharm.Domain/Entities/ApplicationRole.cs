﻿using Microsoft.AspNetCore.Identity;

namespace LocknCharm.Domain.Entities
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedTime { get; set; }
    }
}
