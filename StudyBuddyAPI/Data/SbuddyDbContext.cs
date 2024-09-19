using Microsoft.EntityFrameworkCore;
using StudyBuddyAPI.Models;
using System;
using System.Collections.Generic;
namespace StudyBuddyAPI.Data;

public class SbuddyDbContext : DbContext
{
    public SbuddyDbContext(DbContextOptions<SbuddyDbContext> options) : base(options)
    {

    }

    public DbSet<Question> Questions { get; set; }
    public DbSet<Favorites> Favorites { get; set; }
}
