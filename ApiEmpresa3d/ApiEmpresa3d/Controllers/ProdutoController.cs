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
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly ApiEmpresa3dContext _context;
        public ProdutoController(ILogger<ProdutoController> logger, ApiEmpresa3dContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produto.ToList();
            if(produtos is null)
                return NotFound();

            return produtos;
        }

        [HttpGet("{id:int}", Name="GetProduto")]
        public ActionResult<Produto> Get(int id){
            var produto = _context.Produto.FirstOrDefault(p => p.Id == id);
            if(produto is null)
                return NotFound("Produto não encontrado.");
            
            return produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produto){
            _context.Produto.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetProduto",
            new{ Id = produto.Id},produto);
        } 
        
        [HttpPut("{id:int}")]
        public ActionResult Put ( int id, Produto produto){
            if(id != produto.Id)
                return BadRequest();
            
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges(); 

            return Ok (produto);

        }

        [HttpDelete ("{id:int}")] 
         public ActionResult Delete(int id) {
            var produto= _context.Produto.FirstOrDefault (P=> P.Id == id);

            if (produto is null) {

                return NotFound();
             }
    

                _context.Produto.Remove(produto);
                _context.SaveChanges();
                return Ok (produto);
        }
    }
}