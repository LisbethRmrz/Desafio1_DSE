using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcNotas.Models
{
    public class Notas
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Materia { get; set; }
        public decimal Nota1 { get; set; }
        public decimal Nota2 { get; set; }
        public decimal Nota3 { get; set; }
        public decimal Promedio { get; set; }
        public string Estado { get; set; }
    }

    public class NotasDBContext : DbContext
    {
        public DbSet<Notas> Notas { get; set; }
    }
}