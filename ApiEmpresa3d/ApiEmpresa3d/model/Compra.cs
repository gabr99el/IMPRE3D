using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresa3d.model
{
    public class Compra{
        public List<Produto> produtos;
        public List<Projeto> projetos;

        public int Id{ get; set; }
        public decimal ValorTotal{ get; set; }
        public DateTime DataCompra{ get; set; }
    }
}