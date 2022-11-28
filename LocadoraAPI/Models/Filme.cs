using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Text.Json.Serialization;

namespace LocadoraAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Diretor { get; set; }

        [Range(1,900,ErrorMessage ="A Duração deve estar entre 1 e 900 minutos")]
        public int Duracao { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
        public int ClassificacaoEtaria { get; set; }

    }
}
