using LogicaDeNegocio.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;

namespace LogicaDeAccesoADatos
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<PagoUnico> PagosUnicos { get; set; }
        public DbSet<Recurrente> Recurrentes { get; set; }
        public DbSet<TipoDeGasto> TipoDeGastos { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Rol> Roles { get; set; }

        public Contexto(DbContextOptions options) : base(options)
        {
        }

        public bool ExisteEmail(string emailFinal)
        {
            return Usuarios.Any(u => u.Mail == emailFinal);
        }
    }
}


