using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet_service
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly MyFinanceDbContext _dbContext;

        public PlanoContaService(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Cadastar(PlanoConta entidade)
        {
            if (entidade.Id == null)
                _dbContext.PlanoConta.Add(entidade);
            else
                _dbContext.PlanoConta.Update(entidade);
            _dbContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var entity = new PlanoConta { Id = id };
            _dbContext.PlanoConta.Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<PlanoConta> ListarRegistros()
        {
            return _dbContext.PlanoConta.ToList();
        }

        public PlanoConta RetornarRegistro(int id)
        {
            return _dbContext.PlanoConta.Where(x => x.Id == id).FirstOrDefault();
        }

    }
}