using Login.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Login.Controllers
{
    [Route("loginUsuarios")]
    public class EndController : ControllerBase
    {

        private readonly pruebaContext context;
        public EndController(pruebaContext conexion)
        {
            context = conexion;
        }
        
        [HttpGet]
        [Route("logiarte")]
        public IActionResult Get(string user1, string password1)
        {
                var usuarios= context.Users;

                var result = usuarios.Where(usuarios => usuarios.user == user1 && usuarios.password == password1);
                return Ok(result);
                
                

                /*
                foreach(var users in context.Users.ToList())
                {
                    Console.WriteLine(users.Password);
                }
                List<User> lista= context.Users.ToList();
                return lista;*/
            
        }
    }

    
}
