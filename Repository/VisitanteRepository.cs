using VisitantesApp.Data;
using VisitantesApp.Interfaces;
using VisitantesApp.Models;
using VisitantesApp.ViewModels;

namespace VisitantesApp.Repository
{
    public class VisitanteRepository : IVisitante
    {
        private readonly ApplicationDbContext _context;

        public VisitanteRepository(ApplicationDbContext context)
        {
             _context = context;
        }
        public async Task<AgregarVisitanteViewModel> AgregarVisitante(AgregarVisitanteViewModel info)
        {
            if (info is null) 
            {
                return null;
            }

            Visitante visitante = new Visitante
            {
                Nombre = info.Nombre,   
                Apellido = info.Apellido
                
            };

            _context.Visitantes.Add(visitante);
            int result = await _context.SaveChangesAsync();

            if (result >= 0)
            {

                Visitante? ultimoVisitante = _context.Visitantes   
                       .OrderByDescending(v => v.Id)
                       .FirstOrDefault();

                if (ultimoVisitante is null)
                {
                    return null;
                }

                Eventos? ultimoEvento = UltimoEventoCreado();
                
                
                if (ultimoEvento is null)
                {
                    return null;
                }

                HistoricoVisitas ultimoHistorico = await HistoricoVisitas(ultimoEvento.Id, ultimoVisitante.Id, ultimoEvento.Fecha);

                if (ultimoHistorico is null)
                {
                    return null;
                }

                return new AgregarVisitanteViewModel
                {
                    Nombre = ultimoVisitante.Nombre,
                    Apellido = ultimoVisitante.Apellido,
                    Evento = await EventoViewModel(info.Evento),
                    FechaUltimaVisita = LeerFechaHistorico(ultimoHistorico.FechaUltimoEvento)
                };
            }
            return null;
            
        }

        public async Task<EventoViewModel> EventoViewModel(EventoViewModel eventoViewModel)

        { 
         if (eventoViewModel is null) 
            {

                return null;
            
            }

            Eventos evento = new Eventos

            {
                Nombre = eventoViewModel.Nombre,
                Descripcion = eventoViewModel.Descripcion,               
                Fecha = DateTimeOffset.Parse(eventoViewModel.Fecha).ToUnixTimeMilliseconds(),
            };

            _context.Eventos.Add(evento);

           int result =  await _context.SaveChangesAsync();

            if ( result >= 0)
            {

                Eventos? ultimoEvento = UltimoEventoCreado();

                if(ultimoEvento is null)
                {

                    return null;
                }

                return new EventoViewModel
                {
                    Nombre = ultimoEvento.Nombre,
                    Descripcion = ultimoEvento.Descripcion,
                    Fecha = DateTimeOffset.FromUnixTimeMilliseconds(ultimoEvento.Fecha).ToString(), 
                };

            }

           return null;
           
        }

        public async Task<HistoricoVisitas> HistoricoVisitas(int eventId, int visitanteId, long fechaUltimoEvento)
        {
            if (eventId <= 0 || visitanteId <= 0)
            { 
            
                return null;
            
            }

            HistoricoVisitas historico = new HistoricoVisitas
            {

                EventoId = eventId,
                VisitanteId = visitanteId,
                FechaUltimoEvento = fechaUltimoEvento,
            };

            _context.HistoricoVisitas.Add(historico);

            int result = await _context.SaveChangesAsync();

            if (result >= 0) 
            
            { 
                HistoricoVisitas? ultimoHistoricoVisitas = _context.HistoricoVisitas
                    .OrderByDescending(h => h.Id)
                    .FirstOrDefault();
                    

                if (ultimoHistoricoVisitas is null) 
                {
                    return null;
                
                }

                return ultimoHistoricoVisitas;
            
            
            }
            return null;


        }

 

        private DateTimeOffset? LeerFechaHistorico(long fecha)
        {
            if (fecha <= 0)
            {
                return null;
            }

            return DateTimeOffset.FromUnixTimeMilliseconds(fecha);
        }

        private Eventos? UltimoEventoCreado()
        {
            return _context.Eventos
                      .OrderByDescending(e => e.Id)
                      .FirstOrDefault();
        }
    }
}
