using Microsoft.AspNetCore.Mvc;
using tl2_tp07_2023_jm07_web.Models;
using tl2_tp07_2023_jm07_web.AccesoADatos;

namespace tl2_tp07_2023_jm07_web.Controllers;

[ApiController]
[Route("[controller]")]

public class TareaController : ControllerBase
{
    private ManejoTareas manejoTareas;
    private AccesoADatosTarea ADTarea;

    public TareaController()
    {
        manejoTareas = new ManejoTareas();
        ADTarea = new AccesoADatosTarea();
        manejoTareas.ListadoTareas = ADTarea.Leer();
    }

    [HttpPost]
    public IActionResult CrearTarea([FromBody] Tarea nuevaTarea)
    {
        if (nuevaTarea == null)
        {
            return BadRequest("El pedido no puede ser nulo.");
        }

        var nuevo = manejoTareas.Crear(nuevaTarea);
        ADTarea.Guardar(manejoTareas.ListadoTareas);
        return Created("", "Tarea creada exitosamente");
    }

    [HttpGet("ObtenerPorId")]
    public IActionResult ObtenerTareaPorId(int id)
    {
        var tarea = manejoTareas.ObtenerPorId(id);
        if (tarea == null) return NotFound();
        return Ok(tarea);
    }

    [HttpPut("Actualizar")]
    public IActionResult ActualizarTarea(int id, [FromBody] Tarea tareaActualizada)
    {
        var exito = manejoTareas.Actualizar(id, tareaActualizada);
        if (!exito) return NotFound();
        ADTarea.Guardar(manejoTareas.ListadoTareas);
        return Ok();
    }

    [HttpDelete("Eliminar")]
    public IActionResult EliminarTarea(int id)
    {
        var exito = manejoTareas.Eliminar(id);
        if (!exito) return NotFound();
        ADTarea.Guardar(manejoTareas.ListadoTareas);
        return Ok();
    }

    [HttpGet("ListarTareas")]
    public IActionResult ListarTareas()
    {
        return Ok(manejoTareas.ListarTodasLasTareas());
    }
    
    [HttpGet("ListarTareasCompletadas")]
    public ActionResult<List<Tarea>> ListarCompletadas()
    {
        return Ok(manejoTareas.ListarTareasCompletadas());
    }
}