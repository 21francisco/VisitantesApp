namespace VisitantesApp.ViewModels
{
    public class AgregarVisitanteViewModel
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTimeOffset? FechaUltimaVisita { get; set; }
        public EventoViewModel Evento { get; set; }
    }
}
