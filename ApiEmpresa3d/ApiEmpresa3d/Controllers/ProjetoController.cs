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
        private readonly ILogger<ProjetoController> _logger;
        private readonly ApiEmpresa3dContext;
        public CursoController()
        (
            _logger = _logger;
            _context = context;
        )

        [HttpGet]
        public ActionResult<IEnumerable<Projeto>> Get()
        {
            var projetos = context.Projetos.ToList();
            if(projetos is null)
                return NotFound();

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