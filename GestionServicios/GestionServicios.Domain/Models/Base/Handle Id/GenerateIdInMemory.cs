namespace GestionServicios.Domain.Models.Base.Handle_Id
{
    /// <summary>
    /// Implementa la generación del ID en un escenario In Memory.
    /// </summary>
    public class GenerateIdInMemory : IGenerateId
    {
        public int Generate()
        {
            return GenerateIncrement.Generate();
        }
    }
}