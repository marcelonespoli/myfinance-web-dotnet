using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_dotnet.Models
{
    public class TransacaoModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Informe o histórico")]
        public string Historico {get; set; }

        [Required(ErrorMessage = "Informe uma data")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Informe um valor")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Selecione um plano de conta")]
        public int PlanoContaId {get; set; }
        public string? Tipo { get; set; }
        public IEnumerable<SelectListItem>? PlanoContas {get; set; }
    }
}