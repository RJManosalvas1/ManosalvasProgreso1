using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ManosalvasProgreso1.Models;

namespace ManosalvasProgreso1.Data
{
    public class ManosalvasProgreso1Context : DbContext
    {
        public ManosalvasProgreso1Context (DbContextOptions<ManosalvasProgreso1Context> options)
            : base(options)
        {
        }

        public DbSet<ManosalvasProgreso1.Models.PropietarioMascota> PropietarioMascota { get; set; } = default!;
        public DbSet<ManosalvasProgreso1.Models.Mascota> Mascota { get; set; } = default!;
        public DbSet<ManosalvasProgreso1.Models.VisitaVeterinaria> VisitaVeterinaria { get; set; } = default!;
    }
}
