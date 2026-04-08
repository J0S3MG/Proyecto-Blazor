using Ejemplo_MudBlazor.Models;
using Ejemplo_MudBlazor.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Ejemplo_MudBlazor.ViewModels;

public class ListaViewModel
{
    private readonly IReunionRepository _repo;
    private readonly NavigationManager _nav;

    #region Propiedades para la Vista
    public string Titulo { get; set; } = "Lista de Reuniones";
    public string TextoBusqueda { get; set; } = "";
    public List<Reunion> Reuniones { get; private set; } = new();
    public List<Reunion> ReunionesFiltradas { get; private set; } = new();
    #endregion

    #region Estados para Modal
    public bool ModalVisible { get; set; }
    public Reunion? ReunionSelec { get; set; }
    #endregion

    public ListaViewModel(IReunionRepository repo, NavigationManager nav)
    {
        _repo = repo;
        _nav = nav;
    }

    public void CargarReuniones()
    {
        Reuniones = _repo.GetAll();
        Filtrar();
    }

    public void Filtrar()
    {
        if (string.IsNullOrWhiteSpace(TextoBusqueda))
            ReunionesFiltradas = Reuniones.ToList();
        else
            ReunionesFiltradas = Reuniones
                .Where(x => x.Desc != null && x.Desc.Contains(TextoBusqueda, StringComparison.OrdinalIgnoreCase))
                .ToList();
    }

    public void IrAFormulario() => _nav.NavigateTo("/form");

    public void IrADetalle(int id) => _nav.NavigateTo($"/detalle/{id}");

    public void ConfirmarBorrado(int id)
    {
        _repo.Delete(id);
        CargarReuniones();
    }

    // ✅ Solo setea estado, el StateHasChanged lo maneja el .razor
    public void SeleccionarParaEditar(Reunion r)
    {
        ReunionSelec = r;
        ModalVisible = true;
    }

    public void GuardarEdicion(Reunion editada)
    {
        _repo.Update(editada);
        ModalVisible = false;
        CargarReuniones();
    }

    public void CerrarModal()
    {
        ModalVisible = false;
    }
}