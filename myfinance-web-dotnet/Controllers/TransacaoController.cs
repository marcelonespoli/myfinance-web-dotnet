using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet.Controllers
{
    [Route("[Controller]")]
    public class TransacaoController : Controller
    {
        private readonly ILogger<TransacaoController> _logger;
        private readonly ITransacaoService _transacaoService;
        private readonly IPlanoContaService _planoContaService;

        public TransacaoController(ILogger<TransacaoController> logger, ITransacaoService transacaoService, IPlanoContaService planoContaService)
        {
            _logger = logger;
            _transacaoService = transacaoService;
            _planoContaService = planoContaService;
        }

        [HttpGet]
        [Route("index")]
        public ActionResult Index()
        {
            var transacoes = _transacaoService.ListarRegistros();
            var result = new List<TransacaoModel>();
            foreach(var item in transacoes)
            {
                var transacao = new TransacaoModel
                {
                    Id = item.Id,
                    Historico = item.Historico,
                    Valor = item.Valor,
                    Data = item.Data,
                    Tipo = item.PlanoConta.Tipo,
                    PlanoContaId = item.PlanoContaId
                };
                result.Add(transacao);
            }
            ViewBag.ListaTransacao = result;
            return View();
        }

        [HttpGet]
        [Route("cadastrar")]
        public ActionResult Cadastrar()
        {   
            var planoContas = new SelectList(_planoContaService.ListarRegistros(), "Id", "Descricao");
            var transacao = new TransacaoModel
            {
                Data = DateTime.Now,
                PlanoContas = planoContas
            };
            return View(transacao);
        }

        [HttpPost]
        [Route("cadastrar")]
        [Route("cadastrar/{id:int}")]
        public ActionResult Cadastrar(TransacaoModel model)
        {
            if (!ModelState.IsValid)
            {
                var planoContas = new SelectList(_planoContaService.ListarRegistros(), "Id", "Descricao");
                model.PlanoContas = planoContas;
                return View(model);
            }

            var transacao = new Transacao
            {
                Id = model.Id,
                Historico = model.Historico,
                Valor = model.Valor,
                Data = model.Data,
                PlanoContaId = model.PlanoContaId
            };            
            _transacaoService.Cadastar(transacao);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("cadastrar/{id:int}")]
        public ActionResult Cadastrar(int id)
        {
            var transacao = _transacaoService.RetornarRegistro(id);
            var planoContas = new SelectList(_planoContaService.ListarRegistros(), "Id", "Descricao");
            var model = new TransacaoModel
            {
                Id = transacao.Id,
                Historico = transacao.Historico,
                Valor = transacao.Valor,
                Data = transacao.Data,
                PlanoContaId = transacao.PlanoContaId,
                PlanoContas = planoContas
            };
            return View(model);
        }

        [HttpGet]
        [Route("excluir/{id:int}")]
        public ActionResult Excluir(int id)
        {
            _transacaoService.Excluir(id);
            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("error")]
        public ActionResult Error()
        {
            return View("Error!");
        }
    }
}