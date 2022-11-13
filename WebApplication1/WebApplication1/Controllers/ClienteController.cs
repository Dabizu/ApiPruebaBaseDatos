using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
namespace WebApplication1 
{
    
    [Route("alumno")]
	public class ClienteController : ControllerBase
	{
        Dao dao;
        public ClienteController()
        {
            dao = new Dao();
        }
        [HttpPost]
        [Route("insertar")]
        public dynamic alta(string id,string nombre)
        {
            dao.insertarAlumno(id, nombre);
            return new { sucess=true};
            /*
            List<Cliente> clientes = new List<Cliente>
            { new Cliente
            {
                id="1",
                nombre="fernando"
            }
            };
            return clientes;*/
        }
        
        [HttpDelete]
        [Route("eliminar")]
        public dynamic baja(string id)
        {
            int res=dao.eliminarAlumno(id);
            if (res == 1)
            {
                return new { sucess = true };
            }
            else
            {
                return new { sucess = false };
            }
        }

        [HttpPut]
        [Route("modificar")]
        public dynamic modificar(string idModificar, string nombre)
        {
            dao.modificar(idModificar, nombre);
            return new { sucess = true };
        }

        [HttpGet]
		[Route("listar")]
		public IActionResult listar()
		{
            DataSet resultado = dao.listarAlumno();
            var alumnosList = resultado.Tables[0].AsEnumerable().
            Select(dataRow => new Alumno
            {
                id = dataRow.Field<int>("id"),
                nombre = dataRow.Field<string>("nombre")
            }).ToList();

            return Ok(alumnosList);
            //return Ok(resultado);
            /*
			List<Cliente> clientes = new List<Cliente>
			{ new Cliente
			{
				id="1",
				nombre="fernando"
			}
			};
			return clientes;*/
        }

	}
}