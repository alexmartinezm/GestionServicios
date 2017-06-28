using System.Collections.Generic;
using GestionServiciosUnitTest.Models;

namespace GestionServiciosUnitTest.Mocks
{
    public class AgentesMock
    {
        public IList<Agente> Agentes { get; set; }

        public AgentesMock()
        {
            Agentes = new List<Agente>()
            {
                new Agente()
                {
                    Tip = 0007
                },
                new Agente()
                {
                    Tip = 8823
                },
                new Agente()
                {
                    Tip = 2292
                }
            };
        }
    }
}