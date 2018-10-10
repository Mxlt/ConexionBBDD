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
        static void Main(string[] args)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["conexionEmpresa"].ConnectionString;
            SqlConnection conexion = new SqlConnection(connectionString);
            string cadena;
            SqlCommand comando;

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

            //HACEMOS UNA CONSULTA A LA TABLA LIBRERIA
            conexion.Open();
            cadena = "SELECT * FROM LIBRERIA";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                Console.WriteLine(registros["TEMA"].ToString() + "\t" + registros["ESTANTE"].ToString() + "\t" + registros["EJEMPLARES"].ToString());
                Console.WriteLine();
            }

            Console.ReadLine();
            conexion.Close();


        }
    }
}

