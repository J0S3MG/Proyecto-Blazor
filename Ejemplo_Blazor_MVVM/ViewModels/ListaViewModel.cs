using Ejemplo_Blazor_MVVM.Models;
using Ejemplo_Blazor_MVVM.Repositories;
using Microsoft.AspNetCore.Components;

namespace Ejemplo_Blazor_MVVM.ViewModels;

public class ListaViewModel
{
    private readonly IReunionRepository _repo;
    private readonly NavigationManager _nav;

    #region  Propiedades para la Vista.
    public string Titulo { get; set; } = "Lista de Reuniones";
    public string TextoBusqueda { get; set; } = "";
    public List<Reunion> Reuniones { get; private set; } = new();
    public List<Reunion> ReunionesFiltradas { get; private set; } = new();
    #endregion

    #region  Estados para Modales y Confirmaciones.
    public bool ModalVisible { get; set; }
    public bool MostrarConfirm { get; set; }
    public Reunion? ReunionSelec { get; set; }
    private int _idABorrar;
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
        {
            ReunionesFiltradas = Reuniones.ToList();
        }
        else
        {
            ReunionesFiltradas = Reuniones.Where(x => x.Desc != null && x.Desc.Contains(TextoBusqueda, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }


    public void IrAFormulario() => _nav.NavigateTo("/form");
    

    public void IrADetalle(int id) => _nav.NavigateTo($"/detalle/{id}");


    public void PrepararBorrado(int id)
    {
        _idABorrar = id;
        MostrarConfirm = true;
    }


    public void ConfirmarBorrado()
    {
        _repo.Delete(_idABorrar);
        MostrarConfirm = false;
        CargarReuniones();
    }


    public void CancelarBorrado() => MostrarConfirm = false;


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


    public void CerrarModal() => ModalVisible = false;
}