using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Tipo
    {
        public Int64 IdTipo{ get; set; }
        public string NombreTipo { get; set; }
        public override string ToString()
        {
            return NombreTipo;
        }
    }
}
