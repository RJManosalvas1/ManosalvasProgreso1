using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManosalvasProgreso1.Models
{
    public class VisitaVeterinaria
    {
        [Key]
        public int IdVisitaVeterinaria { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaVisita { get; set; }

        [Required]
        public MotivoVisita MotivoVisita { get; set; }

        public bool RequiereMedicamento { get; set; }

        public int IdMascota { get; set; }

        [ForeignKey("IdMascota")]
        public Mascota Mascota { get; set; }

        public decimal Tarifa
        {
            get
            {
                return MotivoVisita switch
                {
                    MotivoVisita.Vacunacion => 30m,
                    MotivoVisita.RevisionGeneral => 20m,
                    MotivoVisita.Cirugia => 100m,
                    _ => 0m
                };
            }
        }
    }

    public enum MotivoVisita
    {
        Vacunacion,
        RevisionGeneral,
        Cirugia
    }
}
