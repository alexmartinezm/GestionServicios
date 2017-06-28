using System.Collections.Generic;
using GestionServicios.Domain.Models;

namespace GestionServicios.Mocks.Mocks
{
    public class CallesMock
    {
        public static IList<Calle> Calles = new List<Calle>()
            {
                new Calle()
                {
                    Valor = "Calle la piruleta"
                },
                new Calle()
                {
                    Valor = "Elm Street"
                },
                new Calle()
                {
                    Valor = "Wisconsinnn"
                },
                new Calle()
                {
                    Valor = "Bel Air Guetto"
                }
            };
    }
}