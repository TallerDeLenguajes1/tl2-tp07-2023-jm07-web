namespace tl2_tp07_2023_jm07_web.Models;

/*public enum EstadoTarea
{
    Pendiente,
    EnProgreso,
    Completada   
}*/

public class Tarea
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public string? Descripcion { get; set; }
    public int Estado { get; set; }
    
    public Tarea() {}

    public Tarea(int id, string titulo, string descripcion, int estado)
    {
        Id = id;
        Titulo = titulo;
        Descripcion = descripcion;
        Estado = estado;
    }
}