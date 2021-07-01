using Api.Data.Collections;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadoCollection;
        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadoCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDTO dto)
        {
            var infectado = new Infectado (dto.Nome, dto.DataNascimento, dto.Sexo, dto.Idade, dto.Latitude, dto.Longitude, dto.Curado);
            _infectadoCollection.InsertOne(infectado);
            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpPatch]
        public ActionResult AtualizarInfectado ([FromBody] InfectadoDTO dto)
        {
            _infectadoCollection.UpdateOne(Builders<Infectado>.Filter.Where(_ => _.Nome == dto.Nome), Builders<Infectado>.Update.Set("curado", dto.Curado));
            return StatusCode(202, "Infectado atualizado.");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadoCollection.Find(Builders<Infectado>.Filter.Empty).ToList();
            return Ok(infectados);
        }

        [HttpGet("nome/{nome}")]
        public ActionResult ObterInfectadosPeloNome([FromBody] InfectadoDTO dto)
        {
            var infectados = _infectadoCollection.Find(Builders<Infectado>.Filter.Where(_ => _.Nome == dto.Nome));
            return Ok(infectados);
        }

        [HttpDelete]
        public ActionResult DeletarInfectado ([FromBody] InfectadoDTO dto)
        {
            _infectadoCollection.DeleteOne(Builders<Infectado>.Filter.Where(_ => _.Nome == dto.Nome));
            return Ok("Infectado deletado com sucesso.");
        }

    }
}