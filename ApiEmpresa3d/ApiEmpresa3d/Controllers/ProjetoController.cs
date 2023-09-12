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
    public class ProjetoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Projeto>> Get(){
            var projeto1 = new Projeto{
                Id = 1,
                Nome = "busto",
                dimensoes = "234x534"
            };
            var projeto2 = new Projeto{
                Id = 2,
                Nome = "Action Figure",
                dimensoes = "432x789"
            };

            var projetos = new List<Projeto>();
            projetos.Add(projeto1);
            projetos.Add(projeto2);

            return projetos;
        }

        [HttpGet("{id}")]
        public ActionResult<Projeto> Get(string id){
            var projeto3 = new Projeto{
                Id = 3,
                Nome="capitao america",
                dimensoes="35x54"
            };
            return projeto3;
        }

        [HttpPost]
        public ActionResult<ResponseRequest> Post([FromBody]Projeto projeto){
            var resposta = new ResponseRequest(){
                Codigo = 200,
                Mensagem = "Registro efetuado com sucesso!"
            };
            return resposta;
        }
        
        [HttpPut]
        public ActionResult<ResponseRequest> Put([FromBody]Projeto projeto){
            var resposta = new ResponseRequest(){
                Codigo = 200,
                Mensagem = "Projeto editado com sucesso!"
            };
            return resposta;
        }

        [HttpDelete("{id}")]
        public ActionResult<ResponseRequest> Delete(string id){
            var resposta = new ResponseRequest(){
                Codigo = 200,
                Mensagem = "Projeto deletado com sucesso!"
            };
            return resposta;
        }
    }
}