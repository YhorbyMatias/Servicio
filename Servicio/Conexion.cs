using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Servicio
{
    public class Conexion
    {
        SqlConnection con;

        public Conexion()
        {
            if (con == null)
                con = new SqlConnection("Data Source=s7h75oh7az.database.windows.net,1433;DataBase=softwarev;User id=esneyder;password=alvarez@2014;Integrated Security=false");
            

        }

        public void Abrir()
        {
            if (con.State == ConnectionState.Closed) con.Open();
        }

        public void Cerrar()
        {
            if (con.State == ConnectionState.Open) con.Close();
        }

        // METODOS
        public String InicioSesion(String nic, String clav)
        {
            String msje = "";
            SqlCommand cmd;
            try
            {
                Abrir();
                cmd = new SqlCommand("InicioSesion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user", nic);
                cmd.Parameters.AddWithValue("@clave", clav);
                cmd.Parameters.Add("@msje", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                msje = cmd.Parameters["@msje"].Value.ToString();
                Cerrar();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return msje;
        }
    }
}