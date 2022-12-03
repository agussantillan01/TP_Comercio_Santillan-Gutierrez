using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public  class UsuarioNegocio
    {
       public bool Loguear(Usuario usuario)
       {
            AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearConsulta("Select IdUsuario,TipoUser from Usuarios Where Email=@Email AND Contraseña=@Contraseña");
				datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Contraseña", usuario.Contraseña);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    usuario.Id = (Int64)datos.Lector["IdUsuario"];
                    usuario.TipoUsuario = (int)datos.Lector["TipoUser"] == 2 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
                    return true;
                }
                return false;
            }
			catch (Exception ex)
			{

				throw ex;
			}
            finally
            {
                datos.cerrarConexion();
            }

       }
    }
}