using System.ComponentModel.DataAnnotations;

namespace LocadoraAPI.Data.Gerente
{
    public class UpdateGerenteDto
    {
        [Required]
        public string Nome { get; set; }
    }
}
