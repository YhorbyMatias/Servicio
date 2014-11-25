using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Logica
{
    public class CompraVenta
    {
        public int idventa { get; set; }
        public int idproducto { get; set; }
        public int codUser { get; set; }
        public int cantidad { get; set; }
        public float costo { get; set; }
        public DateTime fecha { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string producto{ get; set; }


        #region Nueva compra
        public int nuevaCompra(CompraVenta com)
        {

            Datos.DatosSistema datos = new Datos.DatosSistema();
            string[] parametros = { "@operacion", "@idventa", "@idproducto", "@codUser", "@cantidad", "@costo", "@fecha"};
            return datos.Ejecutar("compraventaSIAE",
                                    parametros,
                                    "I", "",
                                    com.idproducto,com.codUser,com.cantidad,com.costo,com.fecha);

        }

        #endregion


        #region actualizar compra
        public int actualizarCompra(int idventa)
        {

            Datos.DatosSistema datos = new Datos.DatosSistema();
            string[] parametros = { "@operacion", "@idventa", "@idproducto", "@codUser", "@cantidad", "@costo", "@fecha" };
            return datos.Ejecutar("compraventaSIAE",
                                    parametros,
                                    "A", idventa,
                                    "", "", "", "", "");

        }

        #endregion

        #region eliminar producto
        public int eliminarProducto(int idventa)
        {

            Datos.DatosSistema datos = new Datos.DatosSistema();
            string[] parametros = { "@operacion", "@idventa", "@idproducto", "@codUser", "@cantidad", "@costo", "@fecha" };
            return datos.Ejecutar("compraventaSIAE",
                                    parametros,
                                    "E", idventa,
                                    "", "", "", "", "");

        }

        #endregion

        #region listar compras
        public DataTable listarCompras()
        {

            Datos.DatosSistema datos = new Datos.DatosSistema();
            string[] parametros = { "@operacion", "@idventa", "@idproducto", "@codUser", "@cantidad", "@costo", "@fecha" };
            return datos.getDatos("compraventaSIAE",
                                    parametros,
                                    "S", "",
                                    "", "", "", "", "");

        }

        #endregion
    }
}
