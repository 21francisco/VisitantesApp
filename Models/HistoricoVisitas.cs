namespace VisitantesApp.Models
{
    public class HistoricoVisitas
    {
        public int Id { get; set; }

       public int EventoId { get; set; }

        public int VisitanteId { get; set; }

        public long FechaUltimoEvento { get; set; }
    }
}
