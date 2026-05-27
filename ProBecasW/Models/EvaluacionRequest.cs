namespace ProBecasW.Models
{
    public class EvaluacionRequest
    {
        public decimal PromedioNotas { get; set; }
        public int IngresoFamiliar { get; set; }
        public int IntegrantesFamilia { get; set; }
        public string SituacionLaboral { get; set; } = string.Empty;
    }
}
