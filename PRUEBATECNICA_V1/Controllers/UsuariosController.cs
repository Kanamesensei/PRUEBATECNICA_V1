using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DB;
using Microsoft.EntityFrameworkCore;

namespace PRUEBATECNICA_V1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private DBContext _Context;
        public UsuariosController(DBContext context)
        {
            _Context = context;
        }
        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> CrearUsuario(Usuarios usuario)

        {
            await _Context.Usuarios.AddAsync(usuario);
            await _Context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        [Route("Mostrar")]
        public async Task<ActionResult<IEnumerable<Usuarios>>> ListaUsuarios()
        {
            var usuarios = await _Context.Usuarios.ToListAsync();
            return Ok(usuarios);
        }
        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> ActualizarUsuario(int id, Usuarios usuarios)
        {
            var UsuarioExistente = await _Context.Usuarios.FindAsync(id);
            UsuarioExistente!.Nombre = usuarios.Nombre;
            UsuarioExistente.Apellido = usuarios.Apellido;
            UsuarioExistente.Correo = usuarios.Correo;
            UsuarioExistente.Ocupacion = usuarios.Ocupacion;
            await _Context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var UsuarioBorrado = await _Context.Usuarios.FindAsync(id);
            _Context.Usuarios.Remove(UsuarioBorrado);
            await _Context.SaveChangesAsync();
            return Ok();
        }

    }
}
