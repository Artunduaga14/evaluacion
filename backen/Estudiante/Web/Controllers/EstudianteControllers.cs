using Business.Interface;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteService _estudianteService;

        public EstudianteController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var estudiantes = await _estudianteService.GetAllEstudianteAsync();
            return Ok(estudiantes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var estudiante = await _estudianteService.GetEstudianteByIdAsync(id);
            if (estudiante == null) return NotFound();
            return Ok(estudiante);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Estudiante estudiante)
        {
            await _estudianteService.AddEstudianteAsync(estudiante);
            return CreatedAtAction(nameof(GetById), new { id = estudiante.id }, estudiante);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _estudianteService.DeleteEstudianteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        // ✅ Método PUT para actualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Estudiante estudiante)
        {
            if (id != estudiante.id)
                return BadRequest("El ID de la URL no coincide con el del objeto");

            var existingEstudiante = await _estudianteService.GetEstudianteByIdAsync(id);
            if (existingEstudiante == null)
                return NotFound("Estudiante no encontrado");

            // Aquí puedes actualizar las propiedades que necesites
            existingEstudiante.Nombre = estudiante.Nombre;
            existingEstudiante.Correo = estudiante.Correo;


            await _estudianteService.UpdateEstudianteAsync(existingEstudiante);

            return NoContent(); // 204
        }
    }
}