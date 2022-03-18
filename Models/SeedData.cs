using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMate.Data;
using System;
using System.Linq;

namespace MvcMate.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MateContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MateContext>>()))
            {
                // Look for any Mates.
                if (context.Mate.Any())
                {
                    return;   // DB has been seeded
                }

                context.Mate.AddRange(
                    new Mate
                    {
                        Title = "When Harry Met Sally",
                        BirthDay = DateTime.Parse("1989-2-12"),
                        Name = "Romantic Comedy",
                        Body = "HAHAHA",
                        ImgURL = ""
                    }
                );
                context.SaveChanges();
            }
        }
    }
}