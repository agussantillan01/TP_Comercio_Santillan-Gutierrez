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
        public bool SP_validarUsuario(string email, string pass)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ValidacionUsuario");
                datos.ejecutarLectura();

                //tengo que ver si existe ese email y password en la BD 
                // si existe, retorno true 
                // si no existe retorno false
              

                return true;
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
