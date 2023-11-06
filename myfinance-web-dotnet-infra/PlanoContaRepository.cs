using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myfinance_web_dotnet_infra
{
    public class PlanoContaRepository : Repository<PlanoConta>, IPlanoContaRepository
    {
        public PlanoContaRepository(MyFinanceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
