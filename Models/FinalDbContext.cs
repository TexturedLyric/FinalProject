using System;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class FinalDbContext : DbContext
    {
        public FinalDbContext(DbContextOptions<FinalDbContext> options) : base(options) { }

        public DbSet<Member> Members { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}