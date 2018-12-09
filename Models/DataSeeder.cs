using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProjet.Models
{

    public class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new FinalDbContext(serviceProvider.GetRequiredService<DbContextOptions<BuffteksWebsiteContext>>()))
            {

                //CLIENTS
                if (context.Clients.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                var clients = new List<Client>
                {
                    new Client { FirstName="Joanna", LastName="Summerlin", CompanyName="NameGenorator", Email="jsummerlin@nm.com", Phone="555-555-5555" },
                    new Client { FirstName="Zack", LastName="McGuire", CompanyName="World Animation", Email="zmcguire@wa.com", Phone="555-555-5555" },
                    new Client { FirstName="Stefani", LastName="Wilhelm", CompanyName="Steftography", Email="swilhelm@steftography.com", Phone="555-555-5555" }
                };
                context.AddRange(clients);
                context.SaveChanges();


                // CLIENTS
                if (context.Members.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                var members = new List<Member>
                {
                    new Member { FirstName="Lee", LastName="Baca", Major="CIS", Email="lb0@buff.wt.edu", Phone="555-555-5555" },
                    new Member { FirstName="Tristen", LastName="Huseman", Major="CIS", Email="th0@buff.wt.edu", Phone="555-555-5555" },
                    new Member { FirstName="Daunte", LastName="McCray", Major="CIS", Email="dm0@buff.wt.edu", Phone="555-555-5555" },
                    new Member { FirstName="Anyssa", LastName="Mata", Major="CIS", Email="am0@buff.wt.edu", Phone="555-555-5555" },
                    new Member { FirstName="Kayla", LastName="Wilhelm", Major="CIS", Email="kw0@buff.wt.edu", Phone="555-555-5555" },
                    new Member { FirstName="Kyla", LastName="Matthews", Major="CIS", Email="km0@buff.wt.edu", Phone="555-555-5555" },
                    new Member { FirstName="Sarah", LastName="Stebbins", Major="CIS", Email="ss0@buff.wt.edu", Phone="555-555-5555" }
                };
                context.AddRange(members);
                context.SaveChanges();

                // PROJECTS
                if (context.Projects.Any())
                {
                    //leave, there is already data in the database
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
                    //leave, there is already data in the database
                    return; 
                }

                

                //quickly grab the recent records added to the DB to get the IDs
                var projectsFromDb = context.Projects.ToList();
                var clientsFromDb = context.Clients.ToList();
                var membersFromDb = context.Members.ToList();

                var projectroster = new List<ProjectRoster>
                {
                    //take the first project from above, the first client from above, and the first three students from above.
                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = clientsFromDb.ElementAt(0).ID.ToString(),
                                        ProjectParticipant = clientsFromDb.ElementAt(0) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = membersFromDb.ElementAt(0).ID.ToString(),
                                        ProjectParticipant = membersFromDb.ElementAt(0) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = membersFromDb.ElementAt(1).ID.ToString(),
                                        ProjectParticipant = membersFromDb.ElementAt(1) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = membersFromDb.ElementAt(2).ID.ToString(),
                                        ProjectParticipant = membersFromDb.ElementAt(2) },                                        
                };
                context.AddRange(projectroster);
                context.SaveChanges();                
                
            }
        }
    }
}