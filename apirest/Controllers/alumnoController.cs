using Microsoft.AspNetCore.Mvc;

namespace apirest.Controllers.Controllers{
    public class AlumnoController : ControllerBase{
        [HttpGet]
        [Router("listar")]
        public dynamic listarCliente(){
            
        }
    }
}
