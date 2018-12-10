using System;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class FinalDbContext : DbContext
    {
        public FinalDbContext (DbContextOptions<FinalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectRoster> ProjectRoster { get; set; }

        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Project>().ToTable("Project");


            //Many to Many relationships
            //https://www.learnentityframeworkcore.com/configuration/many-to-many-relationship-configuration

            //establish the join through the keys
            modelBuilder.Entity<ProjectRoster>()
                .HasKey(pr => new {pr.ProjectID, pr.ParticipantID});

            //set up the one to many map from Project to ProjectRoster
            modelBuilder.Entity<ProjectRoster>()
                .HasOne(pr => pr.Project)
                .WithMany(p => p.Participants)
                .HasForeignKey(pr => pr.ProjectID);

            //set up the one to many map from ProjectParticipant to ProjectRoster
            modelBuilder.Entity<ProjectRoster>()
                .HasOne(pr => pr.Participant)
                .WithMany(pp => pp.Projects)
                .HasForeignKey(pr => pr.ParticipantID);

        }
    }
}