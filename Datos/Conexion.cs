using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Datos
{
    public class Conexion
    {
        //creo un objeto SqlConnection con los get y set
        public SqlConnection con { get; set; }
        // retorno cadenaconexión
        public string cadenaConexion()
        {//método para capturar los datos de conexión con la base de datos
            return @"Data Source=s7h75oh7az.database.windows.net,1433;DataBase=softwarev;User id=esneyder;password=alvarez@2014;Integrated Security=false";//cadena conexión
        }
        #region método conexión
        //método con el cual abrimos la conexión con la base de datos
        public SqlConnection conectar()
        {//método de tipo SqlConnection
            con = new SqlConnection(cadenaConexion());//creo un nuevo sqlConnection y le paso la cadena de conexión
            try//usamos try para evitar errores de Exeption
            {
                con.Open();//abro la conexión con el objeto con (SqlConnection)
                return this.con;//retorno la conexión
            }
            catch (Exception)
            {
                return null;// si no paso nada retorno null
            }
        }
        #endregion
        #region deconectar
        //Método para cerrar la conexión
        public void desconectar()
        {//es void pues no retorna nada
            if (this.con != null)//valido si hay conexión
            {
                this.con.Close();//cierro la conexión
            }
        }
        #endregion
    }
}