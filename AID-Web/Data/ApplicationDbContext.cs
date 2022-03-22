﻿using Microsoft.EntityFrameworkCore;

namespace AID.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

    }
}