using System;

namespace Api.Models
{
    public class InfectadoDTO
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool Curado { get; set; }
    }
}