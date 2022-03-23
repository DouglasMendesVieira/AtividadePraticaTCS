using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AtividadePraticaTCS.Models
{
    public class AtividadePraticaTCSContext : DbContext
    {
        public AtividadePraticaTCSContext (DbContextOptions<AtividadePraticaTCSContext> options)
            : base(options)
        {
        }

        public DbSet<Status> Status { get; set; }
        public DbSet<Machine> Machine { get; set; }
        public DbSet<StatusEvent> StatusEvent { get; set; }
    }
}
