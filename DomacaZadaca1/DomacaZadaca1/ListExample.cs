using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomacaZadaca1 {

    class ListExample {

        static void Main(string[] args) {
            IntegerList list = new IntegerList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            // lista je [1,2,3,4,5]
            // Mičemo prvi element liste. 
            list.RemoveAt(0); // Lista je [2,3,4,5]
                              // Mičemo element liste čija je vrijednost "5". 
            list.Remove(5); // Lista je [2,3,4]
            Console.WriteLine(list.Count); // 3
            Console.WriteLine(list.Remove(100)); // false, nemamo element u vrijednosti 100
            Console.WriteLine(list.RemoveAt(5)); // false, nemamo ništa na poziciji 5
                                                 // Brišemo sav sadržaj kolekcije 
            list.Clear();
            Console.WriteLine(list.Count); // 0

            Console.ReadLine();

            IGenericList<string> stringList = new GenericList<string>();
            stringList.Add("Hello");
            stringList.Add("World");
            stringList.Add("!");

            foreach (string value in stringList) {
                Console.WriteLine(value);
            }

            Console.WriteLine(stringList.Count); // 3 
            Console.WriteLine(stringList.Contains("Hello")); // true 
            Console.WriteLine(stringList.IndexOf("Hello")); // 0 
            Console.WriteLine(stringList.GetElement(1)); // World 
            IGenericList<double> doubleList = new GenericList<double>();
            doubleList.Add(0.2);
            doubleList.Add(0.7);

            Console.ReadLine();

        }
    }
}
