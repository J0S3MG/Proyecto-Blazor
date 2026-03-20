using Ejemplo_Blazor_EF.Models;

namespace Ejemplo_Blazor_EF.Interfaces;

public interface IReunionRepository
{
    Reunion Insert(Reunion r);
    List<Reunion> GetAll();
    Reunion? GetById(int id);
    void Update(Reunion r);
    bool Delete(int id);
}