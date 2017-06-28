using System.Collections.Generic;
using GestionServiciosUnitTest.Models;

namespace GestionServiciosUnitTest.Mocks
{
    public class CallesMock
    {
        public IList<Calle> Calles { get; set; }

        public CallesMock()
        {
            Calles = new List<Calle>()
            {
                new Calle()
                {
                    Id = 0,
                    Valor = "Calle la piruleta"
                },
                new Calle()
                {
                    Id = 0,
                    Valor = "Elm Street"
                },
                new Calle()
                {
                    Id = 0,
                    Valor = "Wisconsinnn"
                }
            };
        }
    }
}