using Ejemplo_Blazor_MVVM.Models;

namespace Ejemplo_Blazor_MVVM.Repositories;

public class ReunionRepository: IReunionRepository
{
    public List<Reunion> reunions = new()
    {
        new(1, "Revisión de arquitectura: Implementación de patrón MVVM en el módulo de reuniones.", true),
        new(2, "Sincronización de equipo: Discusión sobre la migración de SQL Server a PostgreSQL.", false),
        new(3, "Capacitación técnica: Mejores prácticas para el uso de Dependency Injection en .NET 8.", false),
        new(4, "Daily meeting: Seguimiento de tareas del Proyecto Verano y despliegue en Railway.", true)
    };

    public Reunion Insert(Reunion r)
    {
        reunions.Add(r);
        return r;
    }
    public List<Reunion> GetAll()
    {
        return reunions;
    }
    public Reunion? GetById(int id)
    {
        return reunions.FirstOrDefault(r => r.Id == id);
    }
    public void Update(Reunion rEdit)
    {
        var index = reunions.FindIndex(r => r.Id == rEdit.Id);
        if (index >= 0) reunions[index] = rEdit;
    }
    public bool Delete(int id)
    {
        var r = reunions.FirstOrDefault(r => r.Id == id);
        if (r != null) reunions.Remove(r);
        return true;
    }
}