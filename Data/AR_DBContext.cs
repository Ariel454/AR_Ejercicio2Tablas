using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AR_Ejercicio2Tablas.Models;

namespace AR_Ejercicio2Tablas.Data
{
    public class AR_DBContext : DbContext
    {
        public AR_DBContext (DbContextOptions<AR_DBContext> options)
            : base(options)
        {
        }

        public DbSet<AR_Ejercicio2Tablas.Models.Burguer> Burguer { get; set; } = default!;

        public DbSet<AR_Ejercicio2Tablas.Models.Promo>? Promo { get; set; }
    }
}
