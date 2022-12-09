using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Producto
    {
        public Int64 Id { get; set; }
        public string Nombre { get; set; }
        public Tipo Tipo { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public int stock { get; set; }
        public int stockMinimo { get; set; }
        public decimal Precio { get; set; }
        public int Porcentaje { get; set; }
        public bool Estado { get; set; }
    }
}
