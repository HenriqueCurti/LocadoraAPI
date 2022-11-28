using LocadoraAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace LocadoraAPI.Data.Dtos.Cinema
{
    public class CreateCinemaDto
    {
       
        [Required(ErrorMessage = "O Campo Nome é Obrigatório")]
        public string Name { get; set; }
        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }
    }
}
