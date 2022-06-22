using Microsoft.EntityFrameworkCore;
using PoupaDev.API.Entities;

namespace PoupaDev.API.Persistence.Repositories
{
    public class ObjetivoFinanceiroRepository : IObjetivoFinanceiroRepository
    {
        private readonly PoupaDevDbContext context;

        public ObjetivoFinanceiroRepository(PoupaDevDbContext context)
            => this.context = context;

        public IEnumerable<ObjetivoFinanceiro> GetAll()
            => context.Objetivos;

        public ObjetivoFinanceiro GetById(int id)
            => context.Objetivos.Include(o => o.Operacoes).SingleOrDefault(s => s.Id == id);

        public void Add(ObjetivoFinanceiro objetivo)
        {
            context.Objetivos.Add(objetivo);

            SaveChanges();
        }

        public void SaveChanges()
            => context.SaveChanges();
    }
}