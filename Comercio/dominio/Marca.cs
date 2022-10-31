using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Marca
    {
        public Int64 Id{ get; set; }
        public string NombreMarca { get; set; }
        public override string ToString()
        {
            return NombreMarca;
        }
    }
}
