using Ejemplo_MudBlazor.Models;

namespace Ejemplo_MudBlazor.Interfaces;

public interface IReunionRepository
{
    Reunion Insert(Reunion r);
    List<Reunion> GetAll();
    Reunion? GetById(int id);
    void Update(Reunion r);
    bool Delete(int id);
}