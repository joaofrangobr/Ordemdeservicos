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
            joao.Senha = "123456";
            joao.Telefone = "44999999999";
            joao.Tipo = "Cliente";

            Usuario herval = new Usuario();
            herval.Id = 2;
            herval.Nome = "ImobiliariaHerval";
            herval.Email = "Herval20@gmail.com";
            herval.Senha = "123456";
            herval.Telefone = "44888888888";
            herval.Tipo = "Imobiliaria";

            Usuario rubens = new Usuario();
            rubens.Id = 3;
            rubens.Nome = "Rubens";
            rubens.Email = "rubens2020@gmail.com";
            rubens.Senha = "123456";
            rubens.Telefone = "44777777777";
            rubens.Tipo = "Prestador";


            usuarios.Add(joao);
            usuarios.Add(herval);
            usuarios.Add(rubens);

            return usuarios;
        }
    }
}
