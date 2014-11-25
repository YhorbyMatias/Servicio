using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Logica
{
   public class Categoria
    {
        public int idcategoria { get; set; }
        public string categoria { get; set; }


        #region nueva categoria
        public int NuevaCategoria(Categoria cate) {
            Datos.DatosSistema datos = new Datos.DatosSistema();
            string[] parametros = {"@operacion","@idcategoria","@categoria" };
            return datos.Ejecutar("spCategoriaIA",
                                    parametros,
                                    "I","",
                                    cate.categoria);
        
        }

        #endregion

        #region ActualizarCategoria
        public int ActualizarCategoria(Categoria cate) {

            Datos.DatosSistema datos = new Datos.DatosSistema();
            string[] parametros = { "@operacion","@idcategoria","@categoria"};
            return datos.Ejecutar("spCategoriaIA", parametros, "A", cate.idcategoria, cate.categoria)
;
        
        
        }
        #endregion


        #region Eliminar Categoria


        public int EliminarCategoria(int categoria)
        {
            Datos.DatosSistema datos = new Datos.DatosSistema();
            string[] parametros = { "@operacion","@idcategoria"};
            return datos.Ejecutar("spCategoriaSE", parametros, "E", categoria);


        }

        #endregion


        #region listado categorias
        public DataTable ListadoCategorias()
        {
            Datos.DatosSistema datos = new Datos.DatosSistema();
            string[] parametros = { "@operacion","@idcategoria"};
            return datos.getDatos("spCategoriaSE", parametros, "Y", 0);
        }

        #endregion

    }
}
