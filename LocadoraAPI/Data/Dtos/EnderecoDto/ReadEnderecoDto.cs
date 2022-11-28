using LocadoraAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace LocadoraAPI.Data.Dtos.Endereco
{
    public class ReadEnderecoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Logadouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
    }
}
