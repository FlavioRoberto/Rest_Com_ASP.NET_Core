using System.Collections.Generic;

namespace Dominio.Conversor
{
    public interface IParse<Origem, Destino>
    {
        Destino Parse(Origem origem);
        List<Destino> ParseList(List<Origem> origem);
    }
}
