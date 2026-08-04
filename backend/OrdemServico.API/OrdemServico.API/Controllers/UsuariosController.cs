namespace OrdemServico.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OrdemServico.API.Models;

    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        public ActionResult <List<Usuario>> Get()
        {
            return Usuario;
        }
    }
}
