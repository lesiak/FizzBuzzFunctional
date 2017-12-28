using System;
using System.Collections.Generic;

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

        public static IEnumerable<(T1 first,T2 second)> Zip<T1, T2>(
            IEnumerable<T1> list1, IEnumerable<T2> list2)
        {
            return ZipWith((x, y) => (x, y), list1, list2);
        }


        public static IEnumerable<TResult> ZipWith<T1, T2, TResult>(
            Func<T1, T2, TResult> zipFunc,
            IEnumerable<T1> list1, IEnumerable<T2> list2)
        {
            using (var enum1 = list1.GetEnumerator())
            using (var enum2 = list2.GetEnumerator())
            {

                while (enum1.MoveNext() && enum2.MoveNext())
                {
                    yield return zipFunc(enum1.Current, enum2.Current);
                }

            }
        }

        public static IEnumerable<int> UnboundedRange(int start)
        {
            for (var i = start;; ++i)
            {
                yield return i;
            }
        }
}
}