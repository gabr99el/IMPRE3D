using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiEmpresa3d.model;

namespace ApiEmpresa3d.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            var usuarios = context.Usuarios.ToList();
            if(usuarios is null)
                return NotFound();

            return usuarios;
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(string id){
            var usuario3 = new Usuario{
                Id = 3,
                Email="",
                Senha=""
            };
            return usuario3;
        }

        [HttpPost]
        public ActionResult<ResponseRequest> Post([FromBody]Usuario usuario){
            var resposta = new ResponseRequest(){
                Codigo = 200,
                Mensagem = "Registro efetuado com sucesso!"
            };
            return resposta;
        }
        
        [HttpPut]
        public ActionResult<ResponseRequest> Put([FromBody]Usuario usuario){
            var resposta = new ResponseRequest(){
                Codigo = 200,
                Mensagem = "Usuario editado com sucesso!"
            };
            return resposta;
        }

        [HttpDelete("{id}")]
        public ActionResult<ResponseRequest> Delete(string id){
            var resposta = new ResponseRequest(){
                Codigo = 200,
                Mensagem = "Usuario deletado com sucesso!"
            };
            return resposta;
        }
    }
}