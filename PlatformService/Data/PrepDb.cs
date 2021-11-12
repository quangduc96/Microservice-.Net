using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());

        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("Seeding data");
                context.Platforms.AddRange(
                    new Platform()
                    {
                        Name = "Dot net",
                        Publisher = "Microsoft",
                        Cost = "free"
                    },

                    new Platform()
                    {
                        Name = "Sql server express",
                        Publisher = "Microsoft",
                        Cost = "free"
                    },

                    new Platform()
                    {
                        Name = "Kubernetes",
                        Publisher = "Cloud navtive coputing foundation",
                        Cost = "free"
                    }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("We already have data");
            }
        }
    }
}
