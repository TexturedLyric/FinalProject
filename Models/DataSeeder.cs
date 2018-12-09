using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProject.Models
{

    public class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new FinalDbContext(serviceProvider.GetRequiredService<DbContextOptions<FinalDbContext>>()))
            {

                //CLIENTS
                if (context.Clients.Any())
                {
                    return; 
                }

                var clients = new List<Client>
                {
                    new Client { FirstName="Joanna", LastName="Summerlin", ClientID="NameGenorator", Email="jsummerlin@nm.com", Phone="555-555-5555" },
                    new Client { FirstName="Zack", LastName="McGuire", ClientID="World Animation", Email="zmcguire@wa.com", Phone="555-555-5555" },
                    new Client { FirstName="Stefani", LastName="Wilhelm", ClientID="Steftography", Email="swilhelm@steftography.com", Phone="555-555-5555" }
                };
                context.AddRange(clients);
                context.SaveChanges();


                // CLIENTS
                if (context.Members.Any())
                {
                    return; 
                }

                var members = new List<Member>
                {
                    new Member { FirstName="Lee", LastName="Baca",Email="lb0@buff.wt.edu", Phone="555-555-5555" },
                    new Member { FirstName="Tristen", LastName="Huseman",Email="th0@buff.wt.edu", Phone="555-555-5555" },
                    new Member { FirstName="Daunte", LastName="McCray",Email="dm0@buff.wt.edu", Phone="555-555-5555" },
                    new Member { FirstName="Anyssa", LastName="Mata",Email="am0@buff.wt.edu", Phone="555-555-5555" },
                    new Member { FirstName="Kayla", LastName="Wilhelm",Email="kw0@buff.wt.edu", Phone="555-555-5555" },
                    new Member { FirstName="Kyla", LastName="Matthews",Email="km0@buff.wt.edu", Phone="555-555-5555" },
                    new Member { FirstName="Sarah", LastName="Stebbins",Email="ss0@buff.wt.edu", Phone="555-555-5555" },
                    new Member { FirstName="Lisa", LastName="Dee",Email="ld0@buff.wt.edu", Phone="555-555-5555" },
                    new Member { FirstName="Andrew", LastName="Wilhem",Email="aw0@buff.wt.edu", Phone="555-555-5555" },
                    new Member { FirstName="Ben", LastName="Seago",Email="bs0@buff.wt.edu", Phone="555-555-5555" },
                };
                context.AddRange(members);
                context.SaveChanges();

                // PROJECTS
                if (context.Projects.Any())
                {
                    return; 
                }

                var projects = new List<Project>
                {
                    new Project { ProjectName="Christmas Project", ProjectDescription="A proposal" },
                    new Project { ProjectName="A better comic", ProjectDescription="Batman vs IronMan" },
                    new Project { ProjectName="More Pictures", ProjectDescription="Taking pictures" }
                };
                context.AddRange(projects);
                context.SaveChanges();

                //PROJECT ROSTER BRIDGE TABLE - THERE MUST BE PROJECTS AND PARTICIPANTS MADE FIRST
                if (context.ProjectRoster.Any())
                {
                    return; 
                }

                

                //grabs the recent records added to the DB to get the IDs
                var projectsFromDb = context.Projects.ToList();
                var clientsFromDb = context.Clients.ToList();
                var membersFromDb = context.Members.ToList();

                var projectroster = new List<ProjectRoster>
                {
                    //take the first project from above, the first client from above, and the first three students from above.
                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ParticipantID = clientsFromDb.ElementAt(0).ID.ToString(),
                                        Participant = clientsFromDb.ElementAt(0) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ParticipantID = membersFromDb.ElementAt(0).ID.ToString(),
                                        Participant = membersFromDb.ElementAt(0) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ParticipantID = membersFromDb.ElementAt(1).ID.ToString(),
                                        Participant = membersFromDb.ElementAt(1) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ParticipantID = membersFromDb.ElementAt(2).ID.ToString(),
                                        Participant = membersFromDb.ElementAt(2) },                                        
                };
                context.AddRange(projectroster);
                context.SaveChanges();                
                
            }
        }
    }
}