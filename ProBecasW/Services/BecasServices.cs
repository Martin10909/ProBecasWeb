
using ProBecasW.Models;
using ProBecasW.Models;

namespace ProBecasW.Services
{
    public class BecaService : IBecaService
    {
        public EvaluacionResponse Evaluar(EvaluacionRequest r)
        {
            int puntaje = 0;

            // Promedio de notas
            puntaje += r.PromedioNotas switch
            {
                >= 6.0m => 40,
                >= 5.0m => 30,
                >= 4.0m => 15,
                _ => 0
            };

            // Ingreso per cápita
            if (r.IntegrantesFamilia > 0)
            {
                decimal perCapita = (decimal)r.IngresoFamiliar / r.IntegrantesFamilia;
                puntaje += perCapita switch
                {
                    <= 200000m => 40,
                    <= 400000m => 25,
                    _ => 10
                };
            }

            // Situación laboral
            if (r.SituacionLaboral?.Trim().ToLower() == "trabaja")
                puntaje += 10;

            // Resultado preliminar
            string resultado = puntaje >= 70 ? "Recomendada"
                             : puntaje >= 50 ? "En revisión"
                             : "No recomendada";

            return new EvaluacionResponse { Puntaje = puntaje, Resultado = resultado };
        }
    }
}
