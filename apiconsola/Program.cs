using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
//using System.Data.SqlClient;
//using Microsoft.Data.Sql;
namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            //declaramos la variable donde se insertaran las opciones
            int opciones;
            //se instancia la clase administradora
            Dao dao=new Dao();
            do
            {
                Console.WriteLine("Menu de opcion");
                Console.WriteLine("1-Alta");
                Console.WriteLine("2-Baja");
                Console.WriteLine("3-Listar");
                Console.WriteLine("0-salir");
                opciones=Int32.Parse(Console.ReadLine());
                switch (opciones)
                {
                    case 1:{
                        Console.Write("Dame id:");
                        string id=Console.ReadLine();
                        Console.Write("dame nombre:");
                        string nombre=Console.ReadLine();
                        dao.insertarAlumno(id,nombre);
                    }break;
                    case 2:{
                        
                    }break;
                    case 3:{

                    }break;
                }
                
            } while (opciones!=0);
        }
    }
}

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
            SqlConnection con=conectarse();
            con.Open();
            Console.WriteLine("conectado");
            comando = new SqlCommand();
            comando.Connection = con;
            comando.CommandText = "insert into Alumno(id,nombre) values(" + id + ",'" + nombre + "')";
            comando.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Todo se hizo perfectamente");

        }
        catch (System.Exception)
        {
            Console.WriteLine("no se conecto");
            throw;
        }
    }
}
/*
class Alumno{
    private string nombre;
    public Alumno(){
        this.nombre="David";
    }
    public string getNombre(){
        return this.nombre;
    }
}*/