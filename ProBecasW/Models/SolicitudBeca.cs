
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProBecasW.Models
{
    public class SolicitudBeca
    {
        [Key]
        public int IdSolicitud { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        [Display(Name = "Nombre del estudiante")]
        public string NombreEstudiante { get; set; } = string.Empty;

        [Required(ErrorMessage = "El RUT es obligatorio")]
        [StringLength(12)]
        [Display(Name = "RUT")]
        public string Rut { get; set; } = string.Empty;

        [Required(ErrorMessage = "La carrera es obligatoria")]
        [StringLength(100)]
        [Display(Name = "Carrera")]
        public string Carrera { get; set; } = string.Empty;

        [Required]
        [Range(1.0, 7.0, ErrorMessage = "El promedio debe estar entre 1.0 y 7.0")]
        [Column(TypeName = "decimal(4,2)")]
        [Display(Name = "Promedio de notas")]
        public decimal PromedioNotas { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "El ingreso debe ser mayor o igual a 0")]
        [Display(Name = "Ingreso familiar mensual")]
        public int IngresoFamiliar { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Debe haber al menos 1 integrante")]
        [Display(Name = "Integrantes del grupo familiar")]
        public int IntegrantesFamilia { get; set; }

        [Required]
        [Display(Name = "Situación laboral")]
        public string SituacionLaboral { get; set; } = "No trabaja";

        [Display(Name = "Puntaje")]
        public int Puntaje { get; set; }

        [Display(Name = "Resultado")]
        public string Resultado { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Estado")]
        public string EstadoSolicitud { get; set; } = "Pendiente";

        [Display(Name = "Fecha de registro")]
        public DateTime FechaSolicitud { get; set; } = DateTime.Now;
    }
}