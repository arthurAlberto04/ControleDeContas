using System.Drawing;

namespace ControleDeConta.Modelos
{
    public class CalculadoraDeJuros : ICalculavelJurosMensal
    {

        public virtual float CalcularJuros(float taxaDeJuros, float valor, DateOnly dataDeInicio)
        {

            return valor *= taxaDeJuros * CalculaMeses(dataDeInicio);

        }
        private int CalculaMeses(DateOnly dataDeInicio)
        {
            int anos = DateOnly.FromDateTime(DateTime.Now).Year - dataDeInicio.Year;
            int meses = DateOnly.FromDateTime(DateTime.Now).Month - dataDeInicio.Month;

            return anos * 12 + meses;
        }
    }
}
