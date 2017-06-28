namespace GestionServiciosUnitTest.Models.Base
{
    /// <summary>
    /// Implementa la generaci�n del ID en un escenario In Memory.
    /// </summary>
    public class GenerateIdInMemory : IGenerateId
    {
        public int Generate()
        {
            return GenerateIncrement.Generate();
        }
    }
}