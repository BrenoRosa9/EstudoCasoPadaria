using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebPadaria.Models;

namespace WebPadaria.Controller.Data
{
    public class Bd_padaria : DbContext
    {
        public Bd_padaria(DbContextOptions<Bd_padaria> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; } = default!;
        public DbSet<Produto> Produto { get; set; } = default!;
        public DbSet<Compra> Compra { get; set; } = default!;
    }
}
