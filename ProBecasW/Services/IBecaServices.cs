using ProBecasW.Models;
using ProBecasW.Models;

namespace ProBecasW.Services

{
    public interface IBecaService
    {
        EvaluacionResponse Evaluar(EvaluacionRequest request);
    }
}
