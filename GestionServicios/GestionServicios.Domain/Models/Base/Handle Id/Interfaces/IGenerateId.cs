namespace GestionServicios.Domain.Models.Base.Handle_Id.Interfaces
{
    /// <summary>
    /// Define las reglas para generar un ID para las entidades.
    /// </summary>
    public interface IGenerateId
    {
        int Generate();
    }
}