using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualRunner.Data.Entities;

namespace VirtualRunner.Data
{
    public class VirtualRunnerDbContext : DbContext
    {
        public VirtualRunnerDbContext(DbContextOptions<VirtualRunnerDbContext> options) : base(options)
        {
        }

        public DbSet<RegistroRunner> RegistrosRunners { get; set; }
        public DbSet<Doacao> Doacoes { get; set; }
    }
}
