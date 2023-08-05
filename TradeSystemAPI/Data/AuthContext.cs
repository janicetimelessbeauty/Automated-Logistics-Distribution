using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace TradeSystemAPI.Data
{
    public class AuthContext : IdentityDbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            string customerID = "1e370876-2ec2-43ab-825e-3674518688e7";
            string adminID = "26575bc3-a19b-460d-844d-afa5e616ff7e";
            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Id = customerID,
                    ConcurrencyStamp = customerID,
                    Name = "Customer",
                    NormalizedName = "Customer".ToUpper()

                },
                new IdentityRole()
                {
                    Id = adminID,
                    ConcurrencyStamp = adminID,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}
