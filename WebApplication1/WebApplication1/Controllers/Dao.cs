
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.Json.Nodes;

namespace WebApplication1
{
    class Dao
    {

        SqlConnection conexion;
        SqlCommand comando;
        public Dao()
        {
        }
        public SqlConnection conectarse()
        {
            return conexion = new SqlConnection(
                        "server=DESKTOP-95ESH7E; database=prueba; integrated security=true"
                    );
        }
        public void insertarAlumno(string id, string nombre)
        {
            try
            {
                SqlConnection con = conectarse();
                con.Open();
                Console.WriteLine("conectado");
                comando = new SqlCommand();
                comando.Connection = con;
                comando.CommandText = "insert into Alumno(id,nombre) values(" + id + ",'" + nombre + "')";
                //comando.ExecuteNonQuery();

                con.Close();
                Console.WriteLine("Todo se hizo perfectamente");

            }
            catch (System.Exception)
            {
                Console.WriteLine("no se conecto");
                throw;
            }
        }
        public int eliminarAlumno(string id)
        {
            int bandera;
            try
            {
                SqlConnection con = conectarse();
                con.Open();
                Console.WriteLine("conectado");
                comando = new SqlCommand();
                comando.Connection = con;
                comando.CommandText = "delete from Alumno where id="+id;
                comando.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Todo se hizo perfectamente");
                bandera = 1;
            }
            catch (System.Exception)
            {
                bandera = 0;
                Console.WriteLine("no se conecto");
                throw;
            }
            return bandera;
        }
        public dynamic listarAlumno()
        {
            try
            {
                SqlConnection con = conectarse();
                con.Open();
                Console.WriteLine("conectado");
                
                SqlDataAdapter da = new SqlDataAdapter("Select * from alumno", con);
                DataSet dsAlumnos = new DataSet();
                //List<Alumno> alumnos = new List<Alumno>();
                da.Fill(dsAlumnos, "Alumno");
                
                con.Close();
                Console.WriteLine("Todo se hizo perfectamente");
                //Console.Write("Dato: " + dsAlumnos.Tables["Alumno"].Rows[0]["id"].ToString() + "\n");
                //return dsAlumnos.Tables["Alumno"].Rows[0]["id"].ToString();
                return dsAlumnos;

            }
            catch (System.Exception)
            {
                Console.WriteLine("no se conecto");
                throw;
            }
        }
        public dynamic buscarAlumno(string id)
        {
            try
            {
                SqlConnection con = conectarse();
                con.Open();
                Console.WriteLine("conectado");
                
                SqlDataAdapter da = new SqlDataAdapter("Select * from alumno where id="+id, con);
                DataSet dsAlumnos = new DataSet();
                da.Fill(dsAlumnos, "Alumno");
                con.Close();
                Console.WriteLine("Todo se hizo perfectamente");
                //Console.Write("Dato: " + dsAlumnos.Tables["Alumno"].Rows[0]["id"].ToString() + "\n");
                //return dsAlumnos.Tables["Alumno"].Rows[0]["id"].ToString();
                return dsAlumnos;
            }
            catch (System.Exception)
            {
                Console.WriteLine("no se conecto");
                throw;
            }
        }

        public dynamic modificar(string id,string nombre)
        {
            try
            {
                SqlConnection con = conectarse();
                con.Open();
                Console.WriteLine("conectado");
                comando = new SqlCommand();
                comando.Connection = con;
                comando.CommandText = "update Alumno set nombre="+nombre+" where id="+id;
                //comando.ExecuteNonQuery();

                con.Close();
                Console.WriteLine("Todo se hizo perfectamente");
                return new { respuesta = 1 };

            }
            catch (System.Exception)
            {
                return new {respuesta = 0 };
                Console.WriteLine("no se conecto");
                throw;
            }
            
        }

    }
}