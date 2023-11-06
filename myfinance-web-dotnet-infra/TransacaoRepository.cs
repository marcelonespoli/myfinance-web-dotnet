using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myfinance_web_dotnet_infra
{
    public class TransacaoRepository : Repository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(MyFinanceDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Transacao> ListarRegistros()
        {
            return _dbSet.Include(x => x.PlanoConta).ToList();
        }
    }
}
