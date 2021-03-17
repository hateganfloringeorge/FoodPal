using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPal.Auth.Context
{
    public class AppIdentityContext: IdentityDbContext<AppUser>
    {
        public DbSet<ProxyApp> ProxyApps { get; set; }
        public AppIdentityContext(DbContextOptions<AppIdentityContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "client", Name = "Client", NormalizedName = "CLIENT" },
                new IdentityRole { Id = "delivery", Name = "Delivery Person", NormalizedName = "DELIVERY_PERSON" },
                new IdentityRole { Id = "admin", Name = "Admin", NormalizedName = "ADMIN" }
            );

            var hasher = new PasswordHasher<AppUser>();

            var user = new AppUser()
            {
                Id = "ADMIN",
                Email = "cristian.hosu@gmail.com",
                UserName = "cristian.hosu@gmail.com"
            };

            user.PasswordHash = hasher.HashPassword(user, "Secret_password_123");

            builder.Entity<AppUser>().HasData(user);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> 
            { 
                RoleId = "admin",
                UserId = "ADMIN"
            });
        }
    }
}
