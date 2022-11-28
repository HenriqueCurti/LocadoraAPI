using System.ComponentModel.DataAnnotations;

namespace LocadoraAPI.Data.Gerente
{
    public class CreateGerenteDto
    {
        [Required]
        public string Nome { get; set; }
    }
}
