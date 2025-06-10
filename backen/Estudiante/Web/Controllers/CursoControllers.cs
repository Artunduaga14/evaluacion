using Business.Interface;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cursos = await _cursoService.GetAllCursoAsync();
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var curso = await _cursoService.GetCursoByIdAsync(id);
            if (curso == null) return NotFound();
            return Ok(curso);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Curso curso)
        {
            await _cursoService.AddCursoAsync(curso);
            return CreatedAtAction(nameof(GetById), new { id = curso.id }, curso);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _cursoService.DeleteCursoAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        // ✅ Método PUT para actualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Curso curso)
        {
            if (id != curso.id)
                return BadRequest("El ID de la URL no coincide con el del objeto");

            var existingCurso = await _cursoService.GetCursoByIdAsync(id);
            if (existingCurso == null)
                return NotFound("Curso no encontrado");

            // Aquí puedes actualizar las propiedades que necesites
            existingCurso.Nombre = curso.Nombre;
            existingCurso.Categoria = curso.Categoria; // Si decides incluir una categoría
    

            await _cursoService.UpdateCursoAsync(existingCurso);

            return NoContent(); // 204
        }
    }
}