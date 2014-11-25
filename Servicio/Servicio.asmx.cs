using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Logica;
using System.Data;

namespace Servicio
{
    /// <summary>
    /// Summary description for Servicio
    /// </summary>
    [WebService(Namespace = "http://esneyder.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Servicio : System.Web.Services.WebService
    {

        Usuario usuario = new Usuario();


        #region usuario

        [WebMethod]
        public String LoginUsuario(string user, String password)
        {
            string msje = "";
            if (usuario.Loguin(user, password))
            {

                msje = "Bienvenido";

            }
            else {

                msje = "Error..";
            }
            return msje;
        }


        [WebMethod]
        public String NuevoUsuario(string nombre,string apellido,string genero,string usuario,string clave) 
        {
            string msje="";
            Usuario user = new Usuario();
            user.nombre = nombre;
            user.apellido = apellido;
            user.genero = genero;
            user.usuario = usuario;
            user.clave =  clave;

            if (user.NuevoUsuario(user) > 0)
            { msje = "Registro ingresado correctamente.!"; }
            else { msje = "Ha acurrido un error al crear el registro....."; }
            return msje;

        }
#endregion

        #region categorias
        [WebMethod]
        public string NuevaCategoria(string ct) {
            Categoria catria = new Categoria();
            catria.categoria = ct;
            string sm = "";
            if (catria.NuevaCategoria(catria) > 0)
            {
                sm = "Registro ingresado";
            }
            else { sm = "Fallo el intento de registro"; }
        
        return sm;
        }


        [WebMethod]
        public string ActualizarCategoria(int id, string categ)
        {
            string sm="";
            Categoria categoria = new Categoria();
            categoria.idcategoria = id;
            categoria.categoria = categ;
            if (categoria.ActualizarCategoria(categoria) > 0)
            {
                sm = "Registro actualizado correctamente..";
            }
            else
            {
                sm = "Ha fallado al actualizar el registro...";
            }

            return sm;
        
        }

        [WebMethod]

        public string EliminarCategoria(int id)
        {
            string sm = "";
            Categoria categoria = new Categoria();
            if (categoria.EliminarCategoria(id) > 0)
            {
                sm = "Registro eliminado correctamente..";
            }
            else {

                sm = "No se pudo eliminar el registro";
            }
            return sm;
        }
        [WebMethod]
        public Categoria[] listarCategorias()
        {

            Categoria com = new Categoria();

            DataTable dt = com.ListadoCategorias();
            List<Categoria> compras = new List<Categoria>();
            foreach (DataRow dr in dt.Rows)
            {
                com = new Categoria();
                com.idcategoria = Convert.ToInt32(dr["idcategoria"]);
                com.categoria = Convert.ToString(dr["categoria"]);
                compras.Add(com);
            }
            return compras.ToArray();


        }
#endregion

        #region compraventa
        [WebMethod]

        public string crearCompraVenta(int idproducto, int codUser, int cantidad, float costo, DateTime fecha)
        {
            string sm = "";
            CompraVenta com = new CompraVenta();
            com.idproducto = idproducto;
            com.codUser = codUser;
            com.cantidad = cantidad;
            com.costo = costo;
            com.fecha = fecha;
            if (com.nuevaCompra(com) > 0)
            {
                sm = "Registro creado correctamente..";
            }
            else
            {

                sm = "No se pudo crear el registro";
            }
            return sm;
        }

        [WebMethod]
        public string actualizarCompraVenta(int id)
        {
            string sm = "";
            CompraVenta com = new CompraVenta();
            
            if (com.actualizarCompra(id) > 0)
            {
                sm = "Registro actualizado correctamente..";
            }
            else
            {

                sm = "No se pudo actualizar el registro";
            }
            return sm;
        }
        [WebMethod]
        public CompraVenta[] listarCompraVenta()
        {
           
            CompraVenta com = new CompraVenta();
            
            DataTable dt=com.listarCompras();
            List<CompraVenta> compras = new List<CompraVenta>();
            foreach (DataRow dr in dt.Rows)
            {
                com = new CompraVenta();
                com.idventa = Convert.ToInt32(dr["idventa"]);
                com.producto=Convert.ToString(dr["producto"]);
                com.nombre=Convert.ToString(dr["nombre"]);
                com.apellidos = Convert.ToString(dr["apellidos"]);
                com.cantidad=Convert.ToInt32(dr["cantidad"]);
                com.costo=(float) Convert.ToDouble(dr["costo"]);
                com.fecha=Convert.ToDateTime(dr["fecha"]);
                compras.Add(com);
            }
            return compras.ToArray();
            
         
        }


        [WebMethod]
        public string eliminarCompraVenta(int id)
        {
            string sm = "";
            CompraVenta com = new CompraVenta();

            if (com.eliminarProducto(id) > 0)
            {
                sm = "Registro eliminar correctamente..";
            }
            else
            {

                sm = "No se pudo eliminar el registro";
            }
            return sm;
        }
        #endregion 

        #region productos
        [WebMethod]

        public string crearproducto(string nombre, string descripcion, string avatar, int idcategoria,float valor, int cantidad)
        {
            string sm = "";
            Producto pro = new Producto();
            pro.nombre = nombre;
            pro.descripcion = descripcion;
            pro.avatar = avatar;
            pro.idcategoria = idcategoria;
            pro.valor = valor;
            pro.cantidad = cantidad;
            if (pro.nuevoProducto(pro) > 0)
            {
                sm = "Registro creado correctamente..";
            }
            else
            {

                sm = "No se pudo crear el registro";
            }
            return sm;
        }

        [WebMethod]
        public string actualizarProducto(int id)
        {
            string sm = "";
            Producto com = new Producto();

            if (com.actualizarProducto(id) > 0)
            {
                sm = "Registro actualizado correctamente..";
            }
            else
            {

                sm = "No se pudo actualizar el registro";
            }
            return sm;
        }
        [WebMethod]
        public Producto[] listarproductos()
        {
           
            Producto com = new Producto();

            DataTable dt = com.listarProducto();
            List<Producto> compras = new List<Producto>();
            foreach (DataRow dr in dt.Rows)
            {
                com = new Producto();
                com.idproduto = Convert.ToInt32(dr["idproducto"]);
                com.nombre = Convert.ToString(dr["nombre"]);
                com.descripcion = Convert.ToString(dr["descripcion"]);
                com.avatar =Convert.ToString(dr["avatar"]);
                com.valor = (float)Convert.ToDouble(dr["valor"]);
                com.idcategoria =Convert.ToInt32(dr["cantidad"]);
                com.categoria= Convert.ToString(dr["categoria"]);
                compras.Add(com);
            }
            return compras.ToArray();


        }


        [WebMethod]
        public string eliminarProducto(int id)
        {
            string sm = "";
            Producto com = new Producto();

            if (com.eliminarProducto(id) > 0)
            {
                sm = "Registro eliminar correctamente..";
            }
            else
            {

                sm = "No se pudo eliminar el registro";
            }
            return sm;
        }
        #endregion

    }
}
