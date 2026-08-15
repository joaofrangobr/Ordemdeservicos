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
        [HttpGet]
        public ActionResult<List<UsuarioResponse>> Get()
        {
            List<Usuario> usuarios = _context.Usuarios.ToList();

            var respostas = usuarios.Select(usuario =>
            {
                UsuarioResponse resposta = new UsuarioResponse();

                resposta.Id = usuario.Id;
                resposta.Nome = usuario.Nome;
                resposta.Email = usuario.Email;
                resposta.Telefone = usuario.Telefone;
                resposta.Tipo = usuario.Tipo;

                return resposta;
            }).ToList();

            return respostas;
        }
        [HttpGet("{id}")]
        public ActionResult<UsuarioResponse> Get(int id)
        {
            Usuario usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }
            UsuarioResponse resposta = new UsuarioResponse();

            resposta.Id = usuario.Id;
            resposta.Nome = usuario.Nome;
            resposta.Email = usuario.Email;
            resposta.Telefone = usuario.Telefone;
            resposta.Tipo = usuario.Tipo;

            return resposta;
        }

        [HttpPost]
        public ActionResult<UsuarioResponse> Post(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);

            _context.SaveChanges();

            UsuarioResponse resposta = new UsuarioResponse();

            resposta.Id = usuario.Id;
            resposta.Nome = usuario.Nome;
            resposta.Email = usuario.Email;
            resposta.Telefone = usuario.Telefone;
            resposta.Tipo = usuario.Tipo;

            return resposta;
        }
        [HttpPut("{id}")]
        public ActionResult<UsuarioResponse> Put(int id, Usuario usuario)
        {
            Usuario usuarioExistente = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);

            if (usuarioExistente == null)
            {
                return NotFound();
            }

            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Email = usuario.Email;
            usuarioExistente.Senha = usuario.Senha;
            usuarioExistente.Telefone = usuario.Telefone;
            usuarioExistente.Tipo = usuario.Tipo;

            _context.SaveChanges();

            UsuarioResponse resposta = new UsuarioResponse();

            resposta.Id = usuarioExistente.Id;
            resposta.Nome = usuarioExistente.Nome;
            resposta.Email = usuarioExistente.Email;
            resposta.Telefone = usuarioExistente.Telefone;
            resposta.Tipo = usuarioExistente.Tipo;

            return resposta;
        }
    }
}
