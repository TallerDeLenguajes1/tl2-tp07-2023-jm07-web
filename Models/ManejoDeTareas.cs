using tl2_tp07_2023_jm07_web.AccesoADatos;

namespace tl2_tp07_2023_jm07_web.Models;

public class ManejoTareas
{
    public List<Tarea> ListadoTareas { get; set; }

    public ManejoTareas()
    {
        ListadoTareas = new List<Tarea>();
    }

    //Metodos
    public Tarea Crear(Tarea tarea)
    {
        tarea.Id = ListadoTareas.Any() ? ListadoTareas.Max(t => t.Id) + 1 : 1;
        ListadoTareas.Add(tarea);
        return tarea;
    }
    public Tarea? ObtenerPorId(int id)
    {
        return ListadoTareas.FirstOrDefault(t => t.Id == id);
    }
    public bool Actualizar(int id, Tarea tareaActualizada)
    {
        var tarea = ListadoTareas.FirstOrDefault(t => t.Id == id);

        if (tarea == null) return false;

        tarea.Titulo = tareaActualizada.Titulo;
        tarea.Descripcion = tareaActualizada.Descripcion;
        tarea.Estado = tareaActualizada.Estado;

        return true;
    }
    public bool Eliminar(int id)
    {
        var tarea = ListadoTareas.FirstOrDefault(t => t.Id == id);
        if (tarea == null) return false;

        ListadoTareas.Remove(tarea);

        return true;
    }
    public List<Tarea> ListarTodasLasTareas()
    {
        return ListadoTareas;
    }
    public List<Tarea> ListarTareasCompletadas()
    {
        return ListadoTareas.Where(t => t.Estado == 2).ToList(); //Estado completado == 2
    }
}