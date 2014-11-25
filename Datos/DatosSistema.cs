using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosSistema
    {
        //el método sirve para consultar registro de una base de datos
        //sean mostrar todos los registro o los que necesitemos
        //es necesario pasarle tres parametros al método
        //1. nombre del procedimiento almacenado
        //2.parametros del procedimientos
        //3. valores de los parametros
        public DataTable getDatos(string procedimiento, string[] parametros, params Object[] valparametro)
        {//de tipo DataTable
            Conexion con = new Conexion();//instancio la conexión
            DataTable dt = new DataTable();//creo una nueva DataTable
            SqlCommand cmd = new SqlCommand();//creo un SqlCommand
            cmd.Connection = con.conectar();//y me conecto a la base de datos en el método conectar
            cmd.CommandText = procedimiento;//le especifico el nombre del procedimiento a ejecutar
            cmd.CommandType = CommandType.StoredProcedure;//le especifico que es un procedimiento almacenado
            if (procedimiento.Length != 0 && parametros.Length == valparametro.Length)//valido que los valores esten y sean correctos
            {
                int i = 0;//creo una variable para recorrer los valores ingresado
                foreach (string parametro in parametros)//recorro los parametros
                    cmd.Parameters.AddWithValue(parametro, valparametro[i++]);//ejecuto los valores que ingresaron
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();//ejecuto la instrucción con el SqlDataReader
                    dt.Load(dr);//cargo los registro en el dt (DataTable)
                    con.desconectar();//cierro la conexión
                    return dt;//retorno el dt (DataTable)
                }
                catch (Exception)
                {
                }
            }
            return dt;//retorno el DataTable
        }
        //método para ejecutar proc en la bd
        //el siguiente método funciona similar al anterior
        //solo que no utilizamos DataTable
        public int Ejecutar(string procedimiento, string[] parametros, params Object[] valparametros)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.conectar();
            cmd.CommandText = procedimiento;
            cmd.CommandType = CommandType.StoredProcedure;
            if (procedimiento.Length != 0 && parametros.Length == valparametros.Length)
            {
                int i = 0;
                foreach (string parametro in parametros)
                    cmd.Parameters.AddWithValue(parametro, valparametros[i++]);
                try
                {
                    //lo unico que cambia es esto
                    //ya que retorna la ejecución directa
                    return cmd.ExecuteNonQuery();//
                }
                catch (Exception)
                {
                }
            }
            return 0;//si no retornamos cero
        }
    }
}