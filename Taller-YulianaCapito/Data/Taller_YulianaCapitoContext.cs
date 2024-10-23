using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taller_YulianaCapito.Models;

namespace Taller_YulianaCapito.Data
{
    public class Taller_YulianaCapitoContext : DbContext
    {
        public Taller_YulianaCapitoContext (DbContextOptions<Taller_YulianaCapitoContext> options)
            : base(options)
        {
        }

        public DbSet<Taller_YulianaCapito.Models.Equipo> Equipo { get; set; } = default!;
        public DbSet<Taller_YulianaCapito.Models.Estadio> Estadio { get; set; } = default!;
        public DbSet<Taller_YulianaCapito.Models.Jugadores> Jugadores { get; set; } = default!;
    }
}
