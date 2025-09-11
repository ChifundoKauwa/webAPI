using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Modules;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<Appuser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions) : base(dbContextOptions)
        {



        }

        public DbSet<Stock> Stock { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name="admin",
                    NormalizedName="ADMIN"
                },
                  new IdentityRole
                {
                    Name="user",
                    NormalizedName="USER"
                },


            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
        
    }
}