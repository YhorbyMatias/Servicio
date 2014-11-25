using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Logica
{
   public class Producto
    {
        public int idproduto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string avatar { get; set; }
        public int idcategoria { get; set; }
        public float valor { get; set; }
        public int cantidad { get; set; }
        public string categoria { get; set; }

        #region Nuevo producto
        public int nuevoProducto(Producto produc) { 
            
            Datos.DatosSistema datos = new Datos.DatosSistema();
            string[] parametros = {"@operacion","@idproducto","@nombre","@descripcion","@avatar","@idcategoria","@valor","@cantidad" };
            return datos.Ejecutar("productosSIAE",
                                    parametros,
                                    "I","",
                                    produc.nombre,produc.descripcion,produc.avatar,produc.idcategoria,produc.valor,produc.cantidad);
      
        }

        #endregion


        #region actualizar producto
        public int actualizarProducto(int idproducto)
        {

            Datos.DatosSistema datos = new Datos.DatosSistema();
            string[] parametros = { "@operacion", "@idproducto", "@nombre", "@descripcion", "@avatar", "@idcategoria", "@valor", "@cantidad" };
            return datos.Ejecutar("productosSIAE",
                                    parametros,
                                    "A", idproducto,
                                    "", "", "", "", "", "");

        }

        #endregion

        #region eliminar producto
        public int eliminarProducto(int idproducto)
        {

            Datos.DatosSistema datos = new Datos.DatosSistema();
            string[] parametros = { "@operacion", "@idproducto", "@nombre", "@descripcion", "@avatar", "@idcategoria", "@valor", "@cantidad" };
            return datos.Ejecutar("productosSIAE",
                                    parametros,
                                    "E", idproducto,
                                    "", "", "", "", "", "");

        }

        #endregion

        #region listar producto
        public DataTable listarProducto()
        {

            Datos.DatosSistema datos = new Datos.DatosSistema();
            string[] parametros = { "@operacion", "@idproducto", "@nombre", "@descripcion", "@avatar", "@idcategoria", "@valor", "@cantidad" };
            return datos.getDatos("productosSIAE",
                                    parametros,
                                    "S", "",
                                    "", "", "", "", "", "");

        }

        #endregion


    }
}
