using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresa3d.model
{
    public class Produto{
        public int Id{ get; set; }

        public string Nome{ get; set; }

        public string dimensoes{ get; set; }
 
        public string Estoque{ get; set; }
        

        public string Preço{ get; set; }
    }
}