using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManosalvasProgreso1.Models
{
    public class VisitaVeterinaria
    {
        [Key]
        public int IdVisitaVeterinaria { get; set; }
        public DateTime FechaVisita { get; set; }
        public string MotivoVisita { get; set; }
        public bool RequiereMedicamento { get; set; }
        public int IdMascota { get; set; }
        [ForeignKey("IdMascota")]
        public Mascota Mascota { get; set; } 
    }
}
