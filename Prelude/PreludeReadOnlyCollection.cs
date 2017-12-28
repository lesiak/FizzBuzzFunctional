using System.Collections.Generic;

namespace Prelude
{
    public static class PreludeReadOnlyCollection
    {
        public static IEnumerable<T> Cycle<T>(this IReadOnlyCollection<T> list) 
        {
            while (true)
            {
                foreach (var item in list)
                {
                    yield return item;
                }
            }
        }
    }
}
