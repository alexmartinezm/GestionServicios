using System.Collections;

namespace GestionServicios.Core.Extensions
{
    public static class HasResultsListExtension
    {
        public static bool HasResults(this IList list)
        {
            return list.Count != 0;
        }
    }
}