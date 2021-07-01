using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Api.Data.Collections
{
    public sealed class Infectado
    {
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Sexo { get; private set; }
        public int Idade { get; private set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; private set; }
        public bool Curado { get; private set; }
        
        public Infectado(string nome, DateTime dataNascimento, string sexo, int idade, double latitude, double longitude, bool curado)
        {
            this.Nome = nome;
            this.Idade = idade;
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
            this.Curado = curado;
        }
    }
}