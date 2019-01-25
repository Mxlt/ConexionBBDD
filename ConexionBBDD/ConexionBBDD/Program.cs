using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ConexionBBDD
{
    class Program
    {
       static String connectionString = ConfigurationManager.ConnectionStrings["conexionVarios"].ConnectionString;
       static SqlConnection conexion = new SqlConnection(connectionString);
       static string cadena;
       static  SqlCommand comando;

        static void Main(string[] args)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["conexionVarios"].ConnectionString;
            SqlConnection conexion = new SqlConnection(connectionString);


            //INSERTAMOS UN REGISTRO A LA TABLA LIBRERIA
            conexion.Open();

            cadena = "INSERT INTO LIBRERIA VALUES ('MECANICA','C',10)";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();

            conexion.Close();

            //EDITAMOS UN REGISTRO DE LA TABLA LIBRERIA
            conexion.Open();

            cadena = "UPDATE LIBRERIA SET EJEMPLARES = 15 WHERE TEMA LIKE'MECANICA'";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();

            conexion.Close();

            ////HACEMOS UNA CONSULTA A LA TABLA LIBRERIA
            conexion.Open();
            cadena = "SELECT max(TEMA) AS 'TEMA' FROM LIBRERIA WHERE TEMA LIKE '%g%'";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();

            while (registros.Read())
            {
                Console.WriteLine(registros[0].ToString() + "\t" + registros[1].ToString() + "\t" + registros["EJEMPLARES"].ToString());
            }

            Console.ReadLine();
            conexion.Close();

            int tema = 4;

            conexion.Open();
            cadena = "SELECT * FROM LIBRERIA WHERE TEMA = " + tema ;
            comando = new SqlCommand(cadena, conexion);
            registros = comando.ExecuteReader();

            if  (registros.Read())
            {
                Console.WriteLine("Existe el registro");
            }else
            {
                Console.WriteLine("El registro no existe");
            }

            Console.ReadLine();
            conexion.Close();
            registros.Close();

        }

    }
}

