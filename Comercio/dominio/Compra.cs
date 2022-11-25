using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class carritoCompra
    {
        public List<Compra> listado { get; set; }
        public decimal total { get; set; }
    }

    public class Compra
    {
        public Int64 Id { get; set; }
        public Producto Producto { get; set; }
        public Proveedor Proveedor { get; set; }
        public Int16 Cantidad { get; set; }
        public decimal Precio { get; set; }

    }
}
