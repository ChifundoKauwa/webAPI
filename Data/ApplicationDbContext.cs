using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Modules;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions <ApplicationDBContext> dbContextOptions) : base(dbContextOptions)
        {

            

        }

        public DbSet<stock> Stock { get; set; }
        public DbSet<Comment>Comments{ get; set; }
        
    }
}