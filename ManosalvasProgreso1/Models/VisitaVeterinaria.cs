using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManosalvasProgreso1.Models
{
    public class VisitaVeterinaria
    {
        [Key]
        public int IdVisitaVeterinaria { get; set; }

        [Required(ErrorMessage = "La fecha de visita es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de la visita")]
        public DateTime FechaVisita { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un motivo de visita.")]
        [Display(Name = "Motivo de la visita")]
        public MotivoVisita MotivoVisita { get; set; }

        [Display(Name = "¿Requiere medicación?")]
        public bool RequiereMedicamento { get; set; }

        [Required]
        [Display(Name = "Mascota")]
        public int IdMascota { get; set; }

        [ForeignKey("IdMascota")]
        public Mascota Mascota { get; set; }

        [NotMapped]
        [Display(Name = "Tarifa estimada")]
        [DataType(DataType.Currency)]
        public decimal Tarifa => MotivoVisita switch
        {
            MotivoVisita.Vacunacion => 30m,
            MotivoVisita.RevisionGeneral => 20m,
            MotivoVisita.Cirugia => 100m,
            _ => 0m
        };
    }

    public enum MotivoVisita
    {
        [Display(Name = "Vacunación")]
        Vacunacion,

        [Display(Name = "Revisión General")]
        RevisionGeneral,

        [Display(Name = "Cirugía")]
        Cirugia
    }
}
