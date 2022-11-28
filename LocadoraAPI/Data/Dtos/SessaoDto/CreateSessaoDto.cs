using System;
using LocadoraAPI.Models;

namespace LocadoraAPI.Data.Dtos.SessaoDto
{
    public class CreateSessaoDto
    {       
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }
       // public DateTime HorarioEncerramento { get; set; }
    }
}
