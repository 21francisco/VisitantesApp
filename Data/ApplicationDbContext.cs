using Microsoft.EntityFrameworkCore;
using VisitantesApp.Models;

namespace VisitantesApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        public DbSet<Visitante> Visitantes { get; set; }

        public DbSet<HistoricoVisitas> HistoricoVisitas { get; set; }

        public DbSet<Eventos> Eventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Visitante Table Configuration

            modelBuilder.Entity<Visitante>()
                .Property(visitante => visitante.Id)
                .HasColumnType("int")
                .IsRequired();
            
            modelBuilder.Entity<Visitante>()
                .Property(visitante => visitante.Nombre)
                .HasColumnType("varchar(800)")
                .IsRequired();

            modelBuilder.Entity<Visitante>()
                .Property(visitante => visitante.Apellido)
                .HasColumnType("varchar(800)")
                .IsRequired();


            // Historico Visitas Configuration


            
            modelBuilder.Entity<HistoricoVisitas>()
                .Property(historicoVisitas => historicoVisitas.Id)
                .HasColumnType("varchar(800)")
                .IsRequired();


            modelBuilder.Entity<HistoricoVisitas>()
                .Property(historicoVisitas => historicoVisitas.FechaUltimoEvento)
                .HasColumnType("bigint")
                .IsRequired();

            modelBuilder.Entity<HistoricoVisitas>()
                .HasOne<Eventos>()
                .WithMany()
                .HasForeignKey(historicoVisitas => historicoVisitas.EventoId);


            modelBuilder.Entity<HistoricoVisitas>()
                .HasOne<Visitante>()
                .WithMany()
                .HasForeignKey(historicoVisitas => historicoVisitas.VisitanteId);


            //Eventos Configuration

            modelBuilder.Entity<Eventos>()
                .Property(eventos => eventos.Id)
                .HasColumnType("int")
                .IsRequired();

            modelBuilder.Entity<Eventos>()
             .Property(eventos => eventos.Nombre)
             .HasColumnType("varchar(800)")
             .IsRequired();

            modelBuilder.Entity<Eventos>()
             .Property(eventos => eventos.Descripcion)
             .HasColumnType("varchar(800)")
             .IsRequired();

            modelBuilder.Entity<Eventos>()
             .Property(eventos => eventos.Fecha)
             .HasColumnType("bigint")
             .IsRequired();




        }

    }


}

