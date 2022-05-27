using System.ComponentModel.DataAnnotations;

namespace VisitantesApp.Models
{
    public class Visitas
    {
        [Key]
        public int VisitaId { get; set; }

        public DateTime FechaSalida { get; set; }
    }
}
