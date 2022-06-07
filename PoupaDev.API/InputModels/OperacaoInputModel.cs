using PoupaDev.API.Enums;

namespace PoupaDev.API.InputModels
{
    public class OperacaoInputModel
    {
        public decimal Valor { get; set; }

        public TipoOperacao TipoOperacao { get; set; }
    }
}