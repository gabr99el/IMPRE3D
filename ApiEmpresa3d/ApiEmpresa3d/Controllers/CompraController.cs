using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiEmpresa3d.model;
using ApiEmpresa3d.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ApiEmpresa3d.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    public class CompraController : ControllerBase
    {
        private readonly ILogger<CompraController> _logger;
        private readonly ApiEmpresa3dContext _context;
        public CompraController(ILogger<CompraController> logger, ApiEmpresa3dContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Compra>> Get()
        {
            var compras = _context.Compra.ToList();
            if(compras is null)
                return NotFound();

            return compras;
        }

        [HttpGet("{id:int}", Name="GetCompra")]
        public ActionResult<Compra> Get(int id){
            var compra = _context.Compra.FirstOrDefault(p => p.Id == id);
            if(compra is null)
                return NotFound("Compra não encontrado.");
            
            return compra;
        }

        [HttpPost]
        public ActionResult Post(Compra compra){
            _context.Compra.Add(compra);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetCompra",
            new{ Id = compra.Id},compra);
        } 
        
        [HttpPut("{id:int}")]
        public ActionResult Put ( int id, Compra compra){
            if(id != compra.Id)
                return BadRequest();
            
            _context.Entry(compra).State = EntityState.Modified;
            _context.SaveChanges(); 

            return Ok (compra);

        }

        [HttpDelete ("{id:int}")] 
         public ActionResult Delete(int id) {
            var compra= _context.Compra.FirstOrDefault (P=> P.Id == id);

            if (compra is null) {

                return NotFound();
             }
    

                _context.Compra.Remove(compra);
                _context.SaveChanges();
                return Ok (compra);
        }
    }
}