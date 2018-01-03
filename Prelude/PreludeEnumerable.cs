using System.Collections.Generic;
using System.Linq;

namespace Prelude
{
    public static class PreludeEnumerable
    {
        public static IEnumerable<(int index, T value)> Enumerate<T>(this IEnumerable<T> list1, int indexStart = 0)
        {
            var index = indexStart;
            using (var enum1 = list1.GetEnumerator())
            {
                while (enum1.MoveNext())
                {
                    yield return (index: index, value: enum1.Current);
                    ++index;
                }
            }
        }

        public static IEnumerable<(T1, T2)> Zip<T1, T2>(
            IEnumerable<T1> list1,
            IEnumerable<T2> list2)
        {
            return list1.Zip(list2, (x, y) => (x, y));
        }

        public static (List<T1>, List<T2>) Unzip<T1, T2>(
            IEnumerable<(T1, T2)> list)
        {
            var ret1 = new List<T1>();
            var ret2 = new List<T2>();
            foreach (var pair in list)
            {
                ret1.Add(pair.Item1);
                ret2.Add(pair.Item2);
            }
            return (ret1, ret2);
        }

        public static IEnumerable<IEnumerable<T>> GroupAt<T>(this IEnumerable<T> source, int itemsPerGroup)
        {
            return source.Select((x, idx) => new {x, idx})
                .GroupBy(x => x.idx / itemsPerGroup)
                .Select(g => g.Select(a => a.x));
        }


        public static IEnumerable<IGrouping<int, T>> GroupAt2<T>(this IEnumerable<T> source, int itemsPerGroup)
        {
            var groupNo = 0;
            using (var sourceEnumerator = source.GetEnumerator())
            {
                while (true)
                {
                    var group = new Grouping<int, T> { Key = groupNo };
                    for (var i = 0; i < itemsPerGroup; ++i)
                    {
                        if (sourceEnumerator.MoveNext())
                        {
                            group.Add(sourceEnumerator.Current);
                        }
                        else
                        {
                            yield return group;
                            yield break;
                        }
                    }
                    yield return group;
                    groupNo++;
                }
            }
        }
        private class Grouping<TKey, TElement> : List<TElement>, IGrouping<TKey, TElement>
        {
            public TKey Key { get; set; }
        }

    }


}