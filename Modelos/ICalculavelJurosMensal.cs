using System.Drawing;

namespace ControleDeConta.Modelos
{
    public interface ICalculavelJurosMensal
    {
        float CalcularJuros(float taxaDeJuros, float valor, DateOnly dataDeInicio);
    }
}
