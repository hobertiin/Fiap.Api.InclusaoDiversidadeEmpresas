using Microsoft.AspNetCore.Mvc;
using InclusaoDiversidadeEmpresas.Models;
using InclusaoDiversidadeEmpresas.Services; // Importante para usar a interface


[Route("api/[controller]")]
[ApiController]
public class ColaboradoresController : ControllerBase
{
    private readonly IColaboradorService _service;

    public ColaboradoresController(IColaboradorService service)
    {
        _service = service;
    }

    // CREATE
    // Mapeado para POST /api/Colaboradores
    [HttpPost]
    public async Task<ActionResult<Colaborador>> PostColaborador(Colaborador colaborador)
    {
      
        var novoColaborador = await _service.AddColaborador(colaborador);

        return CreatedAtAction(nameof(GetColaborador), new { id = novoColaborador.Id }, novoColaborador);
    }

    // READ (LISTAR TODOS)
    // Mapeado para GET /api/Colaboradores
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Colaborador>>> GetColaboradores()
    {
  
        var colaboradores = await _service.GetAllColaboradores();

        return Ok(colaboradores);
    }

    // READ (LISTAR POR ID)
    // Mapeado para GET /api/Colaboradores/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Colaborador>> GetColaborador(long id)
    {
        
        var colaborador = await _service.GetColaboradorById(id);

        if (colaborador == null)
        {
            return NotFound(); 
        }

        return Ok(colaborador); 
    }

    // DELETE (EXCLUIR)
    // Mapeado para DELETE /api/Colaboradores/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteColaborador(long id)
    {
       
        var success = await _service.DeleteColaborador(id);

        if (!success)
        {
            return NotFound(); 
        }

        return NoContent(); 
    }

    // UPDATE (ATUALIZAR)
    // Mapeado para PUT /api/Colaboradores/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutColaborador(long id, Colaborador colaborador)
    {
        if (id != colaborador.Id)
        {
            return BadRequest(); 
        }

        // Chama o método no Service
        var colaboradorAtualizado = await _service.UpdateColaborador(colaborador);

        if (colaboradorAtualizado == null)
        {
            return NotFound(); 
        }

        return NoContent();
    }
}