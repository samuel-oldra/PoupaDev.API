using PoupaDev.API.Enums;

namespace PoupaDev.API.Entities
{
    public class Operacao
    {
        public Operacao(decimal valor, TipoOperacao tipo, int idObjetivo)
        {
            Valor = valor;
            Tipo = tipo;
            IdObjetivo = idObjetivo;
            
            DataOperacao = DateTime.Now;
        }

        public int Id { get; private set; }
        public decimal Valor { get; private set; }
        public TipoOperacao Tipo { get; private set; }
        public int IdObjetivo { get; private set; }
        public DateTime DataOperacao { get; set; }
    }
}