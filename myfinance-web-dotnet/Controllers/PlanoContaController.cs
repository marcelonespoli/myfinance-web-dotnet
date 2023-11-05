using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet.Controllers
{
    [Route("[Controller]")]
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;
        private readonly IPlanoContaService _planoContaService;

        public PlanoContaController(ILogger<PlanoContaController> logger, IPlanoContaService planoContaService)
        {
            _logger = logger;
            _planoContaService = planoContaService;
        }

        [HttpGet]
        [Route("index")]
        public ActionResult Index()
        {
            var planoContas = _planoContaService.ListarRegistros();
            var result = new List<PlanoContaModel>();
            foreach(var plano in planoContas)
            {
                var planoConta = new PlanoContaModel
                {
                    Id = plano.Id,
                    Descricao = plano.Descricao,
                    Tipo = plano.Tipo
                };
                result.Add(planoConta);
            }
            ViewBag.ListaPlanoConta = result;
            return View();
        }

        [HttpGet]
        [Route("cadastrar")]
        public ActionResult Cadastrar()
        {    
            return View();
        }

        [HttpPost]
        [Route("cadastrar")]
        [Route("cadastrar/{id:int}")]
        public ActionResult Cadastrar(PlanoContaModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var planoConta = new PlanoConta
            {
                Id = model.Id,
                Descricao = model.Descricao,
                Tipo = model.Tipo
            };            
            _planoContaService.Cadastar(planoConta);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("cadastrar/{id:int}")]
        public ActionResult Cadastrar(int id)
        {
            var planoConta = _planoContaService.RetornarRegistro(id);
            var model = new PlanoContaModel
            {
                Id = planoConta.Id,
                Descricao = planoConta.Descricao,
                Tipo = planoConta.Tipo
            };
            return View(model);
        }

        [HttpGet]
        [Route("excluir/{id:int}")]
        public ActionResult Excluir(int id)
        {
            _planoContaService.Excluir(id);
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