using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.DataContext;

public class AuthDbContext : IdentityDbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var superAdminRoleId = "e5e7554f-a620-4544-8e39-8e31590bb339";
        var adminRoleId = "758cb7d2-4075-4770-a032-b1d9b29ba76b";
        var userRoleId = "aba546b3-cee7-4b2b-be41-6300a895e7b4";

        // Seed roles (user, admin, superadmin)
        var roles = new List<IdentityRole>
        {
            new IdentityRole()
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                Id = superAdminRoleId,
                ConcurrencyStamp = superAdminRoleId,
            },
            new IdentityRole()
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = adminRoleId,
                ConcurrencyStamp = adminRoleId,
            },
            new IdentityRole()
            {
                Name = "User",
                NormalizedName = "USER",
                Id = userRoleId,
                ConcurrencyStamp = userRoleId,
            }
        };

        modelBuilder.Entity<IdentityRole>().HasData(roles);

        // Seed Super Admin user
        var superAdminId = "cd4bda95-a05b-449d-bb80-7ddfbecc1860";
        var superAdminUser = new IdentityUser
        {
            Id = "cd4bda95-a05b-449d-bb80-7ddfbecc1860",
            UserName = "superadmin@bloggie.com",
            NormalizedUserName = "SUPERADMIN@BLOGGIE.COM",
            Email = "superadmin@bloggie.com"
        };

        superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser, "P@$$w0rd");

        modelBuilder.Entity<IdentityUser>().HasData(superAdminUser);

        // Add all roles to super admin user
        var userRoles = new List<IdentityUserRole<string>>
        {
            new IdentityUserRole<string>
            {
                RoleId = superAdminRoleId,
                UserId = superAdminId
            },
            new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = superAdminId
            },
            new IdentityUserRole<string>
            {
                RoleId = userRoleId,
                UserId = superAdminId
            }
        };

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
    }
}
