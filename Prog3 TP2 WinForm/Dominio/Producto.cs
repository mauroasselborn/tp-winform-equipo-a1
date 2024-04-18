using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int ID { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public Marca marca { get; set; }
        public Categoria categoria { get; set; }
        public Decimal Precio { get; set; }
    }
}
