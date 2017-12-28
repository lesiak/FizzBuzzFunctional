using System;
using System.Collections.Generic;
using System.Linq;
using Prelude;

namespace FizzBuzzFunctional
{
    class Program
    {
        static void Main(string[] args)
        {
            var fizzes = new List<string> { "", "", "Fizz" }.Cycle();
            var buzzes = new List<string> { "", "", "", "", "Buzz" }.Cycle();
            var words = PreludeEnumerable.ZipWith(string.Concat, fizzes, buzzes);
            var numbers = PreludeEnumerable.UnboundedRange(1);

            string Choice(string word, int num) => word == "" ? num.ToString() : word;
            var fizzBuzz = PreludeEnumerable.ZipWith(Choice, words, numbers);

            var output = fizzBuzz.Enumerate(indexStart: 1).Take(20);
            Console.WriteLine(string.Join("\n", output));

            //var zz = PreludeEnumerable.Zip(fizzes, buzzes).Take(20);
            //var x = zz.First().
            //Console.WriteLine(string.Join("\n", zz));
            Console.ReadLine();
        }
    }
}
