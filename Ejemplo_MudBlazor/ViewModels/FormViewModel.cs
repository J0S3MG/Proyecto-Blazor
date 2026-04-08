using Ejemplo_MudBlazor.Models;
using Ejemplo_MudBlazor.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Ejemplo_MudBlazor.ViewModels;

public class FormViewModel
{
    private readonly IReunionRepository _repo;
    private readonly NavigationManager _nav;

    public string Titulo = "Agregar Reunion";
    public int Id { get; set; }
    public Reunion? Reunion { get; set; }

    public FormViewModel(IReunionRepository repo, NavigationManager nav)
    {
        _repo = repo;
        _nav = nav;
    }


    public void VolverAtras() => _nav.NavigateTo("/");
    

    public void AgregarReunion(Reunion r)
    {
      _repo.Insert(r);
      _nav.NavigateTo("/");
    }


}