using RegistroParcial1.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroParcial1.DAL
{
    public class Contexto : DbContext
    {

        public DbSet<Grupos> Grupos { get; set; }

        public Contexto() : base("ConStr"){    }
    }
}
