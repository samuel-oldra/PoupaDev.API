/*

Console.Write("Digite seu nome: ");
var nome = Console.ReadLine();

Console.WriteLine("Hello, " + nome);
Console.WriteLine($"Hello, {nome}");

// variáveis

int numeroInt = 5;
float numeroFloat = 5.4f;
double numeroDouble = 5.4;
decimal numeroDecimal = 5.3m;
char caractere = 'a';
string segundoNome = "Oliveira";
DateTime hoje = DateTime.Now;
DateTime aniversario = new DateTime(1992, 1, 1);
int[] matriz = new int[3] { 1, 2, 3 };

// if-else

Console.WriteLine("Utilizando if-else");

Console.Write("Digite uma opção entre 1 e 3: ");
var opcao = Console.ReadLine();

if (opcao == "1")
{
    Console.WriteLine("if-else: Opção 1 selecionada.");
}
else if (opcao == "2")
{
    Console.WriteLine("if-else: Opção 2 selecionada.");
}
else if (opcao == "3")
{
    Console.WriteLine("if-else: Opção 3 selecionada.");
}
else
{
    Console.WriteLine("if-else: Opção inválida.");
}

// switch-case

Console.WriteLine("Utilizando switch-case");

switch (opcao)
{
    case "1":
        Console.WriteLine("switch-case: Opção 1 selecionada.");
        break;
    case "2":
        Console.WriteLine("switch-case: Opção 2 selecionada.");
        break;
    case "3":
        Console.WriteLine("switch-case: Opção 3 selecionada.");
        break;
    default:
        Console.WriteLine("switch-case: Opção inválida.");
        break;
}

// for

Console.WriteLine("Utilizando for");

Console.Write("Digite uma lista ex. '1 2 3 4 5': ");
var valores = Console.ReadLine(); // "1 2 3 4 5"
var matrizValores = valores.Split(" "); // [ "1", "2", "3", "4", "5" ]

for (var i = 0; i < matrizValores.Length; i++)
{
    Console.WriteLine(matrizValores[i]);
}

// while

Console.WriteLine("Utilizando while");

var contador = 0;

while (contador < matrizValores.Length)
{
    Console.WriteLine(matrizValores[contador]);

    contador++;
}

// list

Console.WriteLine("Utilizando list");

var notasTurma = new List<int> { 10, 5, 2, 3, 10, 4, 3, 2, 7, 2, 5, 1, 4 };

var singleNota1 = notasTurma.Single(n => n == 1);
var primeiroNota10 = notasTurma.First(n => n == 10);
var existeNota1 = notasTurma.Any(n => n == 1);
var ordered = notasTurma.OrderByDescending(n => n);

var min = notasTurma.Min();
var max = notasTurma.Max();
var sum = notasTurma.Sum();
var media = notasTurma.Average();

foreach (var nota in ordered)
{
    Console.WriteLine(nota);
}

*/

// TODO: Formatar e organizar o programa console.

var objetivos = new List<ObjetivoFinanceiro> {
    new ObjetivoFinanceiro("Viagem a Orlando", 25000),
    new ObjetivoFinanceiroComPrazo(new DateTime(2023, 10, 1), "Viagem a Orlando com Prazo", 25000)
};

foreach (var objetivo in objetivos)
    objetivo.ImprimirResumo();

Console.WriteLine();

Console.WriteLine("---- PoupaDev ----");
ExibirMenu();
var opcao = Console.ReadLine();

while (opcao != "0")
{
    switch (opcao)
    {
        case "1":
            // Cadastrar
            CadastrarObjetivo();
            break;

        case "2":
            // Depósito
            RealizarOperacao(TipoOperacao.Deposito);
            break;

        case "3":
            // Saque
            RealizarOperacao(TipoOperacao.Saque);
            break;

        case "4":
            // Detalhes
            ObterDetalhes();
            break;

        default:
            // Opção inválida.
            Console.WriteLine("Opção inválida.");
            break;
    }

    Console.WriteLine();
    Console.WriteLine("---- PoupaDev ----");
    ExibirMenu();
    opcao = Console.ReadLine();
}

void ExibirMenu()
{
    Console.WriteLine("Digite 1 para Cadastro de Objetivo.");
    Console.WriteLine("Digite 2 para Realizar um Depósito.");
    Console.WriteLine("Digite 3 para Realizar um Saque.");
    Console.WriteLine("Digite 4 para Exibir Detalhes de um Objetivo.");
    Console.WriteLine("Digite 0 para Encerrar.");
    Console.Write("Opção: ");
}

void CadastrarObjetivo()
{
    Console.WriteLine();

    Console.Write("Digite um título: ");
    var titulo = Console.ReadLine();

    Console.Write("Digite um valor de objetivo: ");
    var valorLido = Console.ReadLine();
    var valor = decimal.Parse(valorLido);

    var objetivo = new ObjetivoFinanceiro(titulo, valor);
    objetivos.Add(objetivo);

    Console.WriteLine($"Objetivo ID: {objetivo.Id} foi criado com sucesso.");
}

void RealizarOperacao(TipoOperacao tipo)
{
    Console.WriteLine();

    Console.Write("Digite o ID do Objetivo: ");
    var idLido = Console.ReadLine();
    var id = int.Parse(idLido);

    Console.Write("Digite o valor da operação: ");
    var valorLido = Console.ReadLine();
    var valor = decimal.Parse(valorLido);

    var operacao = new Operacao(valor, tipo, id);

    var objetivo = objetivos.SingleOrDefault(o => o.Id == id);

    objetivo.Operacoes.Add(operacao);
}

void ObterDetalhes()
{
    Console.WriteLine();

    Console.Write("Digite o ID do Objetivo: ");
    var idLido = Console.ReadLine();
    var id = int.Parse(idLido);

    var objetivo = objetivos.SingleOrDefault(o => o.Id == id);

    objetivo.ImprimirResumo();
}

public enum TipoOperacao
{
    Saque = 0,
    Deposito = 1
}

public class Operacao
{
    public int Id { get; private set; }

    public decimal Valor { get; private set; }

    public TipoOperacao Tipo { get; private set; }

    public int IdObjetivo { get; private set; }

    public Operacao(decimal valor, TipoOperacao tipo, int idObjetivo)
    {
        Id = new Random().Next(0, 1000);
        Valor = valor;
        Tipo = tipo;
        IdObjetivo = idObjetivo;
    }
}

public class ObjetivoFinanceiro
{
    public int Id { get; private set; }

    public string? Titulo { get; private set; }

    public decimal? ValorObjetivo { get; private set; }

    public List<Operacao> Operacoes { get; private set; }

    public decimal Saldo
        => ObterSaldo();

    public ObjetivoFinanceiro(string? titulo, decimal? valorObjetivo)
    {
        Id = new Random().Next(0, 1000);
        Titulo = titulo;
        ValorObjetivo = valorObjetivo;

        Operacoes = new List<Operacao>();
    }

    public decimal ObterSaldo()
    {
        var totalDeposito = Operacoes
            .Where(o => o.Tipo == TipoOperacao.Deposito)
            .Sum(o => o.Valor);

        var totalSaque = Operacoes
            .Where(o => o.Tipo == TipoOperacao.Saque)
            .Sum(o => o.Valor);

        return totalDeposito - totalSaque;
    }

    public virtual void ImprimirResumo()
        => Console.WriteLine($"Objetivo {Titulo}, Valor: {ValorObjetivo}, com Saldo Atual: R$ {Saldo}");
}

public class ObjetivoFinanceiroComPrazo : ObjetivoFinanceiro
{
    public DateTime Prazo { get; private set; }

    public ObjetivoFinanceiroComPrazo(DateTime prazo, string? titulo, decimal? valorObjetivo)
        : base(titulo, valorObjetivo)
        => Prazo = prazo;

    public override void ImprimirResumo()
    {
        base.ImprimirResumo();

        var diasRestantes = (Prazo - DateTime.Now).TotalDays;
        var valorRestante = ValorObjetivo - Saldo;

        Console.WriteLine($"Faltam {diasRestantes} para o prazo de seu objetivo, e faltam R${valorRestante} para completar.");
    }
}