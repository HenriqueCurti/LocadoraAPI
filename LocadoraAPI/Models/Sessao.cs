using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Text.Json.Serialization;

namespace LocadoraAPI.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }
       // [JsonIgnore]
        public virtual Cinema Cinema { get; set; }
       // [JsonIgnore]
        public virtual Filme Filme { get; set; }
        public DateTime HorarioEncerramento { get; set; }
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }
    }
}
