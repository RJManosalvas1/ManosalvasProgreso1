using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace ManosalvasProgreso1.Models
{
    public class PropietarioMascota
    {
        [Key]
        public int IdPropietarioMascota { get; set; }
        public string Nombre { get; set; }
        public bool MayorEdad { get; set; } 
        public decimal Telefono { get; set; }
    }
}
