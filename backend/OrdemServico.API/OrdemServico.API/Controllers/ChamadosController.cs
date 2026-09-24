using Microsoft.AspNetCore.Mvc;
using OrdemServico.API.Data;
using OrdemServico.API.Models;

namespace OrdemServico.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChamadosController : ControllerBase
    {
        private readonly OrdemServicoContext _context;
        public ChamadosController(OrdemServicoContext context)
        {
            _context = context;
        }
        [HttpGet] //seleciona todos os chamados
        public ActionResult<List<Chamado>> Get()
        {
            List<Chamado> chamados = _context.Chamados.ToList();
            return chamados;
        }

        [HttpGet("{id}")] // Buscar chamados por id
        public ActionResult<Chamado> Get(int id)
        {
            Chamado chamado = _context.Chamados.FirstOrDefault(chamado => chamado.Id == id);

            if (chamado == null)
            {
                return NotFound();
            }
            return chamado;
        }

        [HttpPost] // Adicionar Chamados
        public ActionResult<Chamado> Post(Chamado chamado)
        {
            if (chamado == null)
            {
                return BadRequest();
            }

            // usa a FK presente em 'chamado' (ex.: UsuarioId)
            Usuario cliente = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == usuario.Id);
            if (cliente == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            // se houver propriedade de navegação, associe-a (opcional)
            // chamado.Usuario = cliente;

            _context.Chamados.Add(chamado);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = chamado.Id }, chamado);
        }

        [HttpPost("{id}")] // Adicionar Chamados vinculando ao usuário {id}
        public ActionResult<Chamado> Post([FromRoute] int id, [FromBody] Chamado chamado)
        {
            if (chamado == null)
            {
                return BadRequest();
            }
            

            Usuario cliente = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == chamado.ClienteId);
            if (cliente == null)
            {
                return NotFound("Usuário não encontrado.");
            }
            if (cliente.Tipo != "Cliente")
            {
                return BadRequest("O usuário informado não é um cliente.");
            }
            
            // opcional: associe o usuário ao chamado se houver propriedade de navegação
            // chamado.Usuario = cliente;
            // ou defina a FK: chamado.UsuarioId = id;

            _context.Chamados.Add(chamado);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = chamado.Id }, chamado);
        }
    }
}