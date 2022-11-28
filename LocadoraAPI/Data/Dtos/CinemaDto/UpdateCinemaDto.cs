using System.ComponentModel.DataAnnotations;

namespace LocadoraAPI.Data.Dtos.Cinema
{
    public class UpdateCinemaDto
    {

        [Required(ErrorMessage = "O Campo Nome é Obrigatório")]
        public string Name { get; set; }
    }
}
