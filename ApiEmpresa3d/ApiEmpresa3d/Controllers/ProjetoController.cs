using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiEmpresa3d.model;
using ApiEmpresa3d.Context;

namespace ApiEmpresa3d.Controllers
{
    [Route("api/[controller]")]
    public class ProjetoController : ControllerBase
    {
        private readonly ILogger<ProjetoController> _logger;
        private readonly ApiEmpresa3dContext _context;
        public ProjetoController(ILogger<ProjetoController> logger, ApiEmpresa3dContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Projeto>> Get()
        {
            var projetos = _context.Projeto.ToList();
            if(projetos is null)
                return NotFound();

            return projetos;
        }

        [HttpGet("{id:int}", Name="GetProjeto")]
        public ActionResult<Projeto> Get(int id){
            var projeto = _context.Projeto.FirstOrDefault(p => p.Id == id);
            if(projeto is null)
                return NotFound("Projeto não encontrado.");
            
            return projeto;
        }

        [HttpPost]
        public ActionResult Post(Projeto projeto){
            _context.Projeto.Add(projeto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetProjeto",
            new{ id = projeto.Id},projeto);
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