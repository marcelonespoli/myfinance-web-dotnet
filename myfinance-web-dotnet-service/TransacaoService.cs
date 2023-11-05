using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet_service
{
    public class TransacaoServiceService : ITransacaoService
    {
        private readonly MyFinanceDbContext _dbContext;

        public TransacaoServiceService(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Cadastar(Transacao entidade)
        {
            if (entidade.Id == null)
                _dbContext.Transacao.Add(entidade);
            else
                _dbContext.Transacao.Update(entidade);
            _dbContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var entity = new Transacao { Id = id };
            _dbContext.Transacao.Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<Transacao> ListarRegistros()
        {
            return _dbContext.Transacao.Include(x => x.PlanoConta).ToList();
        }

        public Transacao RetornarRegistro(int id)
        {
            return _dbContext.Transacao.Where(x => x.Id == id).FirstOrDefault();
        }

    }
}