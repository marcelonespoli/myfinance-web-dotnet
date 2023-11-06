using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_domain.Interfaces;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet_service
{
    public class TransacaoServiceService : ITransacaoService
    {
        private readonly ITransacaoRepository _transacaoRepository;

        public TransacaoServiceService(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }

        public void Cadastar(Transacao entidade)
        {
            _transacaoRepository.Cadastar(entidade);
        }

        public void Excluir(int id)
        {
            _transacaoRepository.Excluir(id);
        }

        public List<Transacao> ListarRegistros()
        {
            return _transacaoRepository.ListarRegistros();
        }

        public Transacao RetornarRegistro(int id)
        {
            return _transacaoRepository.RetornarRegistro(id);
        }

    }
}