namespace GestionServiciosUnitTest.Models.Base
{
    /// <summary>
    /// Define las reglas para generar un ID para las entidades.
    /// </summary>
    public interface IGenerateId
    {
        int Generate();
    }
}