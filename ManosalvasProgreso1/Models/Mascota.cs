using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManosalvasProgreso1.Models
{
    public class Mascota
    {
        [Key]
        public int IdMascota { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public string Color { get; set; }
        public string Sexo { get; set; }
        [ForeignKey("Propietario")]
        public int IdPropietario { get; set; }
        public int edad { get; set; }
        public ICollection<VisitaVeterinaria> VisitasVeterinarias { get; set; }
    }
}
