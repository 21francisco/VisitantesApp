using VisitantesApp.Models;
using VisitantesApp.ViewModels;

namespace VisitantesApp.Interfaces
{
    public interface IVisitante

    {

        Task<AgregarVisitanteViewModel> AgregarVisitante(AgregarVisitanteViewModel visitante);

        Task<EventoViewModel> EventoViewModel(EventoViewModel eventoViewModel);

        Task<HistoricoVisitas> HistoricoVisitas(int eventId , int visitanteId, long fechaUltimoEvento);

    }
}
