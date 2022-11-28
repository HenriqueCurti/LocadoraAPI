using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace LocadoraAPI.Data.Gerente
{
    public class ReadGerenteDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public object Cinemas { get; set; }

    }
}
