﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficerEngagement.Models
{
    public class EngagementContext:IdentityDbContext<AppilicationUser>
    {
        public EngagementContext(DbContextOptions<EngagementContext> options)
            : base(options)
        {

        }

        public DbSet<Engagement> Engagements { get; set; }
    }
}
