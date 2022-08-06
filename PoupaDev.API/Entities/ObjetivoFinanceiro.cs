using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoupaDev.API.Enums;
using PoupaDev.API.Exceptions;

namespace PoupaDev.API.Entities
{
    public class ObjetivoFinanceiro
    {
        private const decimal RENDIMENTO = 0.03m;
        public ObjetivoFinanceiro(string? titulo, string? descricao, decimal? valorObjetivo)
        {
            Titulo = titulo;
            Descricao = descricao;
            ValorObjetivo = valorObjetivo;

            DataCriacao = DateTime.Now;

            Operacoes = new List<Operacao>();
        }

        public int Id { get; private set; }
        public string? Titulo { get; private set; }
        public string? Descricao { get; private set; }
        public decimal? ValorObjetivo { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public List<Operacao> Operacoes { get; private set; }
        public decimal Saldo => ObterSaldo();

        public void RealizarOperacao(Operacao operacao) {
            if (operacao.Tipo == TipoOperacao.Saque && Saldo < operacao.Valor)
                throw new SaldoInsuficienteException();

            Operacoes.Add(operacao);
        }

        public decimal ObterSaldo(){
            var totalDeposito = Operacoes.Where(o => o.Tipo == TipoOperacao.Deposito).Sum(d => d.Valor);
            var totalSaque = Operacoes.Where(o => o.Tipo == TipoOperacao.Saque).Sum(s => s.Valor);

            return totalDeposito - totalSaque;
        }

        public void Render() {
            var valorRendimento = Saldo * RENDIMENTO;

            Console.WriteLine($"Saldo {Saldo}, Rendimento: {valorRendimento}");

            var deposito = new Operacao(valorRendimento, TipoOperacao.Deposito, Id);

            Operacoes.Add(deposito);
        }
    }
}