using Microsoft.AspNetCore.Mvc;
using PoupaDev.API.Entities;
using PoupaDev.API.Models;
using PoupaDev.API.Persistence.Repositories;

namespace PoupaDev.API.Controllers
{
    [ApiController]
    [Route("api/objetivos-financeiros")]
    public class ObjetivosFinanceirosController : ControllerBase
    {
        private readonly IObjetivoFinanceiroRepository objetivoFinanceiroRepository;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="objetivoFinanceiroRepository"></param>
        public ObjetivosFinanceirosController(IObjetivoFinanceiroRepository objetivoFinanceiroRepository)
            => this.objetivoFinanceiroRepository = objetivoFinanceiroRepository;

        // GET: api/objetivos-financeiros
        /// <summary>
        /// Listagem de Objetivos Financeiros
        /// </summary>
        /// <returns>Lista de Objetivos Financeiros</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetTodos()
        {
            var objetivos = objetivoFinanceiroRepository.GetAll();

            return Ok(objetivos);
        }

        // GET: api/objetivos-financeiros/{id}
        /// <summary>
        /// Detalhes do Objetivo Financeiro
        /// </summary>
        /// <param name="id">ID do Objetivo Financeiro</param>
        /// <returns>Mostra um Objetivo Financeiro</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPorId(int id)
        {
            var objetivo = objetivoFinanceiroRepository.GetById(id);

            if (objetivo == null)
                return NotFound("Objetivo Financeiro não encontrado.");

            return Ok(objetivo);
        }

        // POST: api/objetivos-financeiros
        /// <summary>
        /// Cadastro de Objetivo Financeiro
        /// </summary>
        /// <remarks>
        /// Requisição:
        /// {
        ///     "titulo": "Viagem para Orlando",
        ///     "descricao": "Economizar para viajar para Orlando",
        ///     "valorObjetivo": 15000
        /// }
        /// </remarks>
        /// <param name="model">Dados do Objetivo Financeiro</param>
        /// <returns>Objeto criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(ObjetivoFinanceiroInputModel model)
        {
            var objetivo = new ObjetivoFinanceiro(model.Titulo, model.Descricao, model.ValorObjetivo);

            objetivoFinanceiroRepository.Add(objetivo);

            return CreatedAtAction("GetPorId", new { objetivo.Id }, model);
        }

        // POST: api/objetivos-financeiros/{id}/operacoes
        /// <summary>
        /// Cadastro de Operação Financeira
        /// </summary>
        /// <remarks>
        /// Requisição:
        /// {
        ///     "valor": 100,
        ///     "tipoOperacao": 1
        /// }
        /// </remarks>
        /// <param name="id">ID do Objetivo Financeiro</param>
        /// <param name="model">Dados da Operação Financeira</param>
        /// <response code="204">Sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Não encontrado</response>
        [HttpPost("{id}/operacoes")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PostOperacao(int id, OperacaoInputModel model)
        {
            var operacao = new Operacao(model.Valor, model.TipoOperacao, id);

            var objetivo = objetivoFinanceiroRepository.GetById(id);

            if (objetivo == null)
                return NotFound("Objetivo Financeiro não encontrado.");

            objetivo.RealizarOperacao(operacao);

            objetivoFinanceiroRepository.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <returns></returns>
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
            => Problem();
    }
}