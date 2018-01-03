using System;
using System.Collections.Generic;

namespace Prelude
{
    public static class PreludeInfiniteEnumerable
    {
        /// <summary>
        /// Iterate(f, x) returns an infinite list of repeated applications of f to x:
        /// Iterate(f, x) == [x, f x, f (f x), ...]
        /// </summary>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> Iterate<T>(Func<T,T> f, T x)
        {
            var currentVal = x;
            while (true)
            {
                yield return currentVal;
                currentVal = f(currentVal);
            }
        }
        
        /// <summary>
        /// Repeat(x) is an infinite list, with x the value of every element.
        /// </summary>
        /// <param name="x"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> Repeat<T>(T x)
        {
            while (true)
            {
                yield return x;
            }
        }
        
        /// <summary>
        /// Cycle ties a finite list into a circular one, or equivalently, the infinite repetition of the original list. 
        /// It is the identity on infinite lists.
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
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
        
        public static IEnumerable<int> UnboundedRange(int start)
        {
            for (var i = start;; ++i)
            {
                yield return i;
            }
        }
    }
}