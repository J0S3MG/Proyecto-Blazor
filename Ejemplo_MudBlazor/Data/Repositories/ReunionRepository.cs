using Ejemplo_MudBlazor.Models;
using Ejemplo_MudBlazor.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo_MudBlazor.Data.Repositories;

public class ReunionRepository: IReunionRepository
{
    private readonly ReunionContext _context;

    public ReunionRepository(ReunionContext context) => _context = context;

    public Reunion Insert(Reunion r)
    {
        var insertResult = _context.Reuniones.Add(r);
        _context.SaveChanges();
        return insertResult.Entity;
    }


    public List<Reunion> GetAll() => _context.Reuniones.ToList();


    public Reunion? GetById(int id) => _context.Reuniones.FirstOrDefault(r => r.Id == id);


    public void Update(Reunion rEdit)
    {
        _context.Reuniones.Update(rEdit);
        _context.SaveChanges();
    }


    public bool Delete(int id)
    {
        var r = GetById(id);
        if (r is null) return false;
        _context.Reuniones.Remove(r);
        _context.SaveChanges();
        return true;
    }
}