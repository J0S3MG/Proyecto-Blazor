namespace Ejemplo_Blazor_EF.Models;

public class Reunion
{
    public int Id { get; set; }
    public string? Desc { get; set; }
    public bool Virtual { get; set; }

    public Reunion(){ }
    public Reunion(int id, string? desc, bool v)
    {
        Id = id;
        Desc = desc;
        Virtual = v;
    }
}
