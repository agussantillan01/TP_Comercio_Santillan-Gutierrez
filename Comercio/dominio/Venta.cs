using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class listaTotalVenta
    {
        public List<Venta> listado { get; set; }

        public decimal total { get; set; } // Precio total de toda la venta 
    }
    public class Venta
    {
        public Int64 Id { get; set; }
        public Cliente Cliente { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; } // Precio del valor del producto * cantidad 
    }
}
