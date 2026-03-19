using Ejemplo_Blazor.Models;

namespace Ejemplo_Blazor.Repositories;

public interface IReunionRepository
{
    Reunion Insert(Reunion r);
    List<Reunion> GetAll();
    Reunion? GetById(int id);
    void Update(Reunion r);
    bool Delete(int id);
}