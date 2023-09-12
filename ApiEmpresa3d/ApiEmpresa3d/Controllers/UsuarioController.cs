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
        public ActionResult<List<Usuario>> Get(){
            var usuario1 = new Usuario{
                Id = 1,
                Email="BB@gmail.com",
                Senha="darthvader123"
            };
            var usuario2 = new Usuario{
                Id = 2,
                Email="MarxMaciel@gmail.com",
                Senha="Marx123456"
            };

            var usuarios = new List<Usuario>();
            usuarios.Add(usuario1);
            usuarios.Add(usuario2);

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