using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
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