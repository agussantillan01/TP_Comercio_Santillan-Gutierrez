using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public enum TipoUsuario
    {
        NORMAL=1,
        ADMIN=2

    }
    public class Usuario
    {
        public Int64 Id { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        public Usuario(string user, string pass, bool admin)
        {
            Email = user;
            Contraseña = pass;
            TipoUsuario = admin ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;

        }
        public Usuario()
        {
            Id = Id;
            Email= Email;
            Contraseña = Contraseña; 
        }

  
    }
     
}
