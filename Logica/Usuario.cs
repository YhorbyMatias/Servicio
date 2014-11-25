using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using System.Data;

namespace Logica
{
    public class Usuario
    {
        public int codUser { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string genero { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }



        #region login

        public bool Loguin(string usuario, string password)
        {
            DatosSistema datos = new DatosSistema();
            string[] parametros = {"@operacion","@usuario","@clave" };
            DataTable tb = datos.getDatos("spUsuarioS", parametros, "S", usuario, password);   
            if (tb.Rows.Count > 0)
            {
                return true;
            }
            return false;
               
        }
         
        #endregion
                        
        #region crear usuario
        public int NuevoUsuario(Usuario user)
        {

            DatosSistema datos = new DatosSistema();
            string[] parametros = {"@operacion",
                                      "@nombre",
                                      "@apellidos",
                                      "@sexo",
                                      "@usuario",
                                      "@clave"};

            return datos.Ejecutar("usuariosSIAE", parametros, "I", user.nombre, user.apellido, user.genero, user.usuario, user.clave);
        
        
        
        }
        #endregion
        



    }
}
