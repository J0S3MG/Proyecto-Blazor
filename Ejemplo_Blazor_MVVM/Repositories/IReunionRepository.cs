using Ejemplo_Blazor_MVVM.Models;

namespace Ejemplo_Blazor_MVVM.Repositories;

public interface IReunionRepository
{
    Reunion Insert(Reunion r);
    List<Reunion> GetAll();
    Reunion? GetById(int id);
    void Update(Reunion r);
    bool Delete(int id);
}