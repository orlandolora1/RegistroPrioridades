using System.ComponentModel.DataAnnotations;

    public class Prioridades
    {
        [Key]

        public int PrioridadId { get; set; }

        [Required (ErrorMessage = "La descripcion es obligatoria")]

        public string? Descripcion { get; set; }

        [Required (ErrorMessage = "Los dias de compromiso son obligatorios")]

        public string? DiasCompromiso { get; set; }
    }