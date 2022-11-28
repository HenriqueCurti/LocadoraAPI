using LocadoraAPI.Data.Dtos.Cinema;
using LocadoraAPI.Data.Dtos.Filme;
using LocadoraAPI.Models;
using System;
using System.Data;

namespace LocadoraAPI.Data.Dtos.SessaoDto


{
    public class ReadSessaoDto
    {
        public int Id { get; set; }
        public Models.Cinema Cinema { get; set; }
        public Models.Filme Filme { get; set; }
        public DateTime HorarioEncerramento { get; set; }
    }
}
