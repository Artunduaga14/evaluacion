using Business.Interface;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _matriculaService;

        public MatriculaController(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var matriculas = await _matriculaService.GetAllMatriculaAsync();
            return Ok(matriculas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var matricula = await _matriculaService.GetMatriculaByIdAsync(id);
            if (matricula == null) return NotFound();
            return Ok(matricula);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Matricula matricula)
        {
            await _matriculaService.AddMatriculaAsync(matricula);
            return CreatedAtAction(nameof(GetById), new { id = matricula.id }, matricula);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _matriculaService.DeleteMatriculaAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        // ✅ Método PUT para actualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Matricula matricula)
        {
            if (id != matricula.id)
                return BadRequest("El ID de la URL no coincide con el del objeto");

            var existingMatricula = await _matriculaService.GetMatriculaByIdAsync(id);
            if (existingMatricula == null)
                return NotFound("Matrícula no encontrada");

            // Aquí puedes actualizar las propiedades que necesites
            existingMatricula.FechaMatricula = matricula.FechaMatricula;
            existingMatricula.EstudianteId = matricula.EstudianteId;
            existingMatricula.CursoId = matricula.CursoId;

            await _matriculaService.UpdateMatriculaAsync(existingMatricula);

            return NoContent(); // 204
        }
    }
}