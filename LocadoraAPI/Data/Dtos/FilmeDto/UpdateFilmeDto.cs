using System.ComponentModel.DataAnnotations;

namespace LocadoraAPI.Data.Dtos.Filme
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Diretor { get; set; }

        [Range(1, 900, ErrorMessage = "A Duração deve estar entre 1 e 900 minutos")]
        public int Duracao { get; set; }
        public int ClassificacaoEtaria { get; set; }
    }
}
