#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMate.Models;

namespace MvcMate.Data
{
    public class MateContext : DbContext
    {
        public MateContext (DbContextOptions<MateContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMate.Models.Mate> Mate { get; set; }
    }
}
