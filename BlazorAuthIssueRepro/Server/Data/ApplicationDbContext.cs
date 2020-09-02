using BlazorAuthIssueRepro.Server.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAuthIssueRepro.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }

    #region Configurations

    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> modelBuilder)
        {
            var rolesToSeed = new List<IdentityRole>();
            foreach (var roleName in Shared.UserRoles.GetUserRoles())
            {
                var roleID = Shared.UserRoles.GetRoleID(roleName);
                if (Guid.TryParse(roleID, out _))
                    rolesToSeed.Add(new IdentityRole() { Id = roleID, Name = roleName, NormalizedName = roleName.ToUpper() });
            }

            modelBuilder.HasData(rolesToSeed);
        }
    }

    #endregion
}
