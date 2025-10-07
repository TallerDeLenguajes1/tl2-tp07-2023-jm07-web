using System.Text.Json;
using tl2_tp07_2023_jm07_web.Models;

namespace tl2_tp07_2023_jm07_web.AccesoADatos;

public class AccesoADatosTarea
{
    private const string rutaTareasJSON = "Data/Archivo.json";

    public List<Tarea> Leer()
    {
        if (File.Exists(rutaTareasJSON))
        {
            string json = File.ReadAllText(rutaTareasJSON);
            return JsonSerializer.Deserialize<List<Tarea>>(json)!;
        }

        return new List<Tarea>();
    }

    public void Guardar(List<Tarea> tareas)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(tareas, options);
        File.WriteAllText(rutaTareasJSON, json);
    }
}