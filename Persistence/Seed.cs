using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any()) 
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        UserName = "bob",
                        Email = "bob@test.com"
                    },
                    new AppUser
                    {
                        UserName = "tom",
                        Email = "tom@test.com"
                    },
                    new AppUser
                    {
                        UserName = "jane",
                        Email = "jane@test.com"
                    }
                };

                foreach(var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }

            if (context.Constituents.Any()) return;
            
            var constituents = new List<Constituent>
            {
                new Constituent
                {
                    ConstituentName = "JTCL"
                },
                new Constituent
                {
                    ConstituentName = "BDTCL"
                },
                new Constituent
                {
                    ConstituentName = "APL-Adani"
                    
                },
                new Constituent
                {
                    ConstituentName = "wrldc"
                    
                },
                new Constituent
                {
                    ConstituentName = "POWERGRID-WR2 (PGCIL)"
                    
                },
                new Constituent
                {
                    ConstituentName = "KSK"
                    
                },
                new Constituent
                {
                    ConstituentName = "STERLITE"
                    
                }
            };

            await context.Constituents.AddRangeAsync(constituents);
            await context.SaveChangesAsync();
        }
    }
}