using Fubon_T.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Fubon_T.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }

}
