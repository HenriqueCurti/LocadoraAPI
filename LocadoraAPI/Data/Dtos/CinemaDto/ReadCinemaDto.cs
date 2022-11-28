using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using LocadoraAPI.Data.Dtos.Endereco;
using LocadoraAPI.Data.Gerente;
using LocadoraAPI.Models;


namespace LocadoraAPI.Data.Dtos.Cinema
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Campo Nome é Obrigatório")]
        public string Name { get; set; }
        public Models.Endereco Endereco { get; set; }
        public Models.Gerente Gerente { get; set; }
    }
}
