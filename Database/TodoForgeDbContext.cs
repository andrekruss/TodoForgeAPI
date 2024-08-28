using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class TodoForgeDbContext : DbContext
    {

        public TodoForgeDbContext(DbContextOptions options) : base(options)
        {
               
        }

        public DbSet<User> Users { get; set; }
    }
}
