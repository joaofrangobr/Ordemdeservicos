namespace OrdemServico.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OrdemServico.API.Models;

    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            List<Usuario> usuarios = new List<Usuario>();

            Usuario joao = new Usuario();

            joao.Id = 1;
            joao.Nome = "João";
            joao.Email = "joao20@gmail.com";
            joao.Telefone = "44999999999";
            joao.Tipo = "Cliente";

            usuarios.Add(joao);

            return usuarios;
        }
    }
}
