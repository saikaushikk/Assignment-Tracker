using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AssignmentTracker.Data;
using System;
using System.Linq;

namespace AssignmentTracker.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AssignmentTrackerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AssignmentTrackerContext>>()))
            {
                // Look for any movies.
                if (context.Assignment.Any())
                {
                    return;   // DB has been seeded
                }

                context.Assignment.AddRange(
                    new Assignment
                    {
                        Title = "Write an essay on WW2",
                        DueDate = DateTime.Parse("2020-10-12"),
                        Subject = "History",
                        Link = "https://lms.ssn.edu.in/mod/assign/view.php?id=78217"
                    },

                    new Assignment
                    {
                        Title = "Finish a ASP.NET application",
                        DueDate = DateTime.Parse("2020-10-15"),
                        Subject = "C# and .NET",
                        Link = "https://lms.ssn.edu.in/mod/assign/view.php?id=71231"
                    },

                    new Assignment
                    {
                        Title = "Cloud lab exercise 6",
                        DueDate = DateTime.Parse("2020-10-30"),
                        Subject = "Cloud computing",
                        Link = "https://lms.ssn.edu.in/mod/assign/view.php?id=13213"
                    },

                    new Assignment
                    {
                        Title = "Case study on Backpropogation",
                        DueDate = DateTime.Parse("2020-11-12"),
                        Subject = "Machine Learning Techniques",
                        Link = "https://lms.ssn.edu.in/mod/assign/view.php?id=13133"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}