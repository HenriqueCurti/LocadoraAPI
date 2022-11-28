using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;

namespace LocadoraAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required] 
        public int Id { get; set; }       
        [Required(ErrorMessage ="O Campo Nome é Obrigatório")] 
        public string Name { get; set; }
        [JsonIgnore]
        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        [JsonIgnore]
        public virtual Gerente Gerente { get; set; }
        public int GerenteId { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }

    }
}
