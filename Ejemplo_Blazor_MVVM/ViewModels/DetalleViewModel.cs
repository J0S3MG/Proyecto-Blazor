using Ejemplo_Blazor_MVVM.Models;
using Ejemplo_Blazor_MVVM.Repositories;
using Microsoft.AspNetCore.Components;

namespace Ejemplo_Blazor_MVVM.ViewModels;

public class DetalleViewModel
{
    private readonly IReunionRepository _repo;
    private readonly NavigationManager _nav;

    #region  Propiedades para la Vista.
    public string Titulo { get; set; } = "Detalle Reunion";
    public Reunion? Reunion { get; set; } = new();
    #endregion

    #region  Estado para Modal.
    public bool ModalVisible { get; set; }
    public Reunion? ReunionSelec { get; set; }
    #endregion
    public DetalleViewModel(IReunionRepository repo, NavigationManager nav)
    {
        _repo = repo;
        _nav = nav;
    }


    public void CargarReunion(int id)
    {
        Reunion = _repo.GetById(id);
    }


    public void VolverAtras() => _nav.NavigateTo("/");


   public void SeleccionarParaEditar(Reunion r)
    {
        ReunionSelec = r;
        ModalVisible = true;
    }


    public void GuardarEdicion(Reunion editada)
    {
        _repo.Update(editada);
        ModalVisible = false;
        CargarReunion(editada.Id);
    }


    public void CerrarModal() => ModalVisible = false;
}