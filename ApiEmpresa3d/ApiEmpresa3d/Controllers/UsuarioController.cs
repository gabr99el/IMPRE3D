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
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly ApiEmpresa3dContext _context;
        public UsuarioController(ILogger<UsuarioController> logger, ApiEmpresa3dContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            var usuarios = _context.Usuario.ToList();
            if(usuarios is null)
                return NotFound();

            return usuarios;
        }

        [HttpGet("{id:int}", Name="GetUsuario")]
        public ActionResult<Usuario> Get(int id){
            var usuario = _context.Usuario.FirstOrDefault(p => p.Id == id);
            if(usuario is null)
                return NotFound("Usuario não encontrado.");
            
            return usuario;
        }

        [HttpPost]
        public ActionResult Post(Usuario usuario){
            _context.Usuario.Add(usuario);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetUsuario",
            new{ id = usuario.Id},usuario);
        } 


        [HttpPut]
        public ActionResult<ResponseRequest> Put([FromBody]Usuario usuario){
            var resposta = new ResponseRequest(){
                Codigo = 200,
                Mensagem = "Usuario editado com sucesso!"
            };
            return resposta;
        }

        public ActionResult Delete(int Id) {
            var usuario= _context.Usuario.FirstOrDefault (P=> P.Id == Id);

            if (usuario is null) {
                return NotFound();
             }
    
                _context.Usuario.Remove(usuario);
                _context.SaveChanges();
                return Ok (usuario);
        }
    }
}