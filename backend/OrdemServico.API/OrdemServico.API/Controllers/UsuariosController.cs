namespace OrdemServico.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OrdemServico.API.Models;
    using OrdemServico.API.Data;

    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly OrdemServicoContext _context;

        public UsuariosController(OrdemServicoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
           return _context.Usuarios.ToList();
        }
    }
}
