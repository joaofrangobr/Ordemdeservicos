using Microsoft.AspNetCore.Mvc;

namespace OrdemServico.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Joao", "Camila", "Gessica", "Witor", "Heitor", "Scooby",
        ];

        [HttpGet(Name = "GetUsuarios")]
        public IEnumerable<UsuariosController> Get(Username)
        {
            return Enumerable.Range(1, 5).Select(index => new UsuariosController
            {
                Username = Summaries[Random.Shared.Next(Summaries.Length)],
            })
            .ToArray();
        }
    }
}
