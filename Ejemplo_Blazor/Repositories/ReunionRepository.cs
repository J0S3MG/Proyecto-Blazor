using Ejemplo_Blazor.Models;

namespace Ejemplo_Blazor.Repositories;

public class ReunionRepository: IReunionRepository
{
    public List<Reunion> reunions = new()
    {
        new(1, "faihsuidhaiusdhaiurhiuaiuabsiudaisudfbaiusbfdiuasbdf", true),
        new(2, "dasnduasnduiasnduiansiudnasiunduiasnduasodnadasnoidaosidnoiansdoansd", false),
        new(3,"asdasdasdvchiuofhgwekropgjdgfkgmdpogjdsfjguosajreosflsm,dv",false),
        new(4,"adsndausnduasndoasdpas",true)
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