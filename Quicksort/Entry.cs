using System;
using System.Collections.Generic;

namespace Quicksort
{
    class Entry
    {
        static void Main(string[] args)
        {
            PrintableList ints = GetIntArray(1000000);
            PrintableList fewAnimals = getAnimalArray();
            PrintableList integers = GetRandomIntegerArray(1000000);
            PrintableList manyAnimals = GetRandomAnimalArray(1000000);

            //1.000.000 int
            measure(new ComparableSorter(ints));
            //ints.Print();
            //1.000.000 Integer
            measure(new ComparableSorter(integers));
            //1.000.000 Animals
            measure(new ComparableSorter(manyAnimals));
            //10 Animals
            measure(new ComparableSorter(fewAnimals));
            fewAnimals.Print();
        }

        private static void measure(Sorter sorter)
        {
            var start = DateTime.Now;
            //sorter.Sort();
            sorter.ConcurrentSort(2);
            Console.WriteLine(DateTime.Now.Subtract(start));
        }

        private static PrintableList getAnimalArray()
        {
            PrintableList result = new PrintableList(10);

            //Collection Initializer
            List<Animal> animalList = new List<Animal>()
            {
                new Animal{Name = "Antelope"},
                new Animal{Name = "Guanaco"},
                new Animal{Name = "Chipmunk"},
                new Animal{Name = "Hartebeest"},
            };

            //Array Initializer
            Animal[] animals = new Animal[10] 
            {
                null,
                null,
                null,
                null,
                new Animal{Name = "Elk"},
                new Animal{Name = "Lynx"},
                new Animal{Name = "Rat"},
                new Animal{Name = "Orangutan"},
                null,
                null
            };

            //Object Initializer
            result[8] = new Animal { Name = "Marmoset" };

            //Normal Constructor
            result[9] = new Animal("Mare", 10, 20);

            for (int i = 0; i < 8; i++)
                if (i < 4)
                {
                    result[i] = animalList[i];
                }
                else
                {
                    result[i] = animals[i];
                }

            return result;
        }

        private static PrintableList GetRandomAnimalArray(int size)
        {
            PrintableList result = new PrintableList(size);
            Random random = new Random();
            for (int i = 0; i < size; i++)
                result[i] = new Animal() { Name = string.Format("Name{0}", random.Next(size * 100)) };
            return result;
        }

        private static PrintableList GetRandomIntegerArray(int size)
        {
            PrintableList result = new PrintableList(size);
            Random random = new Random();
            for (int i = 0; i < size; i++)
                result[i] = new Integer() { Zahl = random.Next(size * 100) };
            return result;
        }

        private static PrintableList GetIntArray(int size)
        {
            PrintableList result = new PrintableList(size);
            Random random = new Random();
            for (int i = 0; i < size; i++)
                result[i] = random.Next(size * 100);
            return result;
        }
    }
}
