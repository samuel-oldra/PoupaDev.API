using PoupaDev.API.Entities;

namespace PoupaDev.API.Persistence.Repositories
{
    public interface IObjetivoFinanceiroRepository
    {
        IEnumerable<ObjetivoFinanceiro> GetAll();

        ObjetivoFinanceiro GetById(int id);

        void Add(ObjetivoFinanceiro objetivo);

        void SaveChanges();
    }
}