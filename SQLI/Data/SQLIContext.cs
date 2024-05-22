using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SQLI.Models;

namespace SQLI.Data
{
    public class SQLIContext : DbContext
    {
        public SQLIContext (DbContextOptions<SQLIContext> options)
            : base(options)
        {
        }

        public DbSet<SQLI.Models.Admin> Admins { get; set; } = default!;
        public DbSet<SQLI.Models.User> Users { get; set; }
    }
}
