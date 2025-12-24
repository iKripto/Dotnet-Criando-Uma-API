using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {

        private static List<Filme> filmes = new List<Filme>();
        private static int id = 0;

        [HttpPost]
        public void AdicionaFilme([FromBody] Filme filme)
        {
            filmes.Add(filme);
            filme.Id = id++;
            Console.WriteLine(filme.Titulo);
            Console.WriteLine(filme.Genero);
            Console.WriteLine(filme.Duracao);
            Console.WriteLine(filme.Id);
        }
        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes([FromQuery]int skip = 0, [FromQuery]int take = 50) // Exemplo: Para 10 de skip e 10 de take usamos : filme?skip=10&take=10 no postman
        {
            return filmes.Skip(skip).Take(take);
            // Skip(10) = Vai retornar os filmes depois do décimo.
            // Take (10) = Vai retornar apenas 10 filmes.
        }
        [HttpGet("{id}")]
        public Filme? RecuperaFilmePorId([FromRoute] int id)
        {
            return filmes.FirstOrDefault(filme => filme.Id == id);
        }
    }

}