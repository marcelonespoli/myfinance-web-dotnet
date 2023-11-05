using System.ComponentModel.DataAnnotations;

namespace myfinance_web_dotnet.Models
{
    public class PlanoContaModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Informe uma descrição")]
        public string Descricao {get; set; }

        [Required(ErrorMessage = "Informe um tipo de conta")]
        public string Tipo { get; set; }
    }
}