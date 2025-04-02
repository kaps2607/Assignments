using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceWeb.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "41776062 - 6087 - 1fbf - b923 - 2879a6680b9a",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    FirstName = "Admin",
                    LastName = "system",
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Admin@123")

                },
                 new ApplicationUser
                 {
                     Id = "41776062 - 6088 - 1fcf - b923 - 2879a6680b9a",
                     Email = "Mohit@gmail.com",
                     NormalizedEmail = "MOHIT@GMAIL.COM",
                     FirstName = "mohit",
                     LastName = "gupta",
                     UserName = "Mohit@gmail.com",
                     NormalizedUserName = "MOHIT@GMAIL.COM",
                     PasswordHash = hasher.HashPassword(null, "Mohit@123")
                 }


                );
        }
    }
}
