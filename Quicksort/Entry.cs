using System;
using System.Collections.Generic;

namespace Quicksort
{
    class Entry
    {
        static void Main(string[] args)
        {
            PrintableList<int> ints = GetIntArray(1000000);
            PrintableList<Animal> fewAnimals = getAnimalArray();
            PrintableList<Integer> integers = GetRandomIntegerArray(1000000);
            PrintableList<Animal> manyAnimals = GetRandomAnimalArray(1000000);

            //1.000.000 int
            measure(new IntSorter(ints.ts));
            //ints.Print();
            //1.000.000 Integer
            measure(new ComparableSorter<Integer>(integers));
            //1.000.000 Animals
            measure(new ComparableSorter<Animal>(manyAnimals));
            //10 Animals
            measure(new ComparableSorter<Animal>(fewAnimals));
            fewAnimals.Print();
        }

        private static void measure(Sorter sorter)
        {
            var start = DateTime.Now;
            //sorter.Sort();
            sorter.ConcurrentSort(2);
            Console.WriteLine(DateTime.Now.Subtract(start));
        }

        private static PrintableList<Animal> getAnimalArray()
        {
            PrintableList<Animal> result = new PrintableList<Animal>(10);

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

        private static PrintableList<Animal> GetRandomAnimalArray(int size)
        {
            PrintableList<Animal> result = new PrintableList<Animal>(size);
            Random random = new Random();
            for (int i = 0; i < size; i++)
                result[i] = new Animal() { Name = string.Format("Name{0}", random.Next(size * 100)) };
            return result;
        }

        private static PrintableList<Integer> GetRandomIntegerArray(int size)
        {
            PrintableList<Integer> result = new PrintableList<Integer>(size);
            Random random = new Random();
            for (int i = 0; i < size; i++)
                result[i] = new Integer() { Zahl = random.Next(size * 100) };
            return result;
        }

        private static PrintableList<int> GetIntArray(int size)
        {
            PrintableList<int> result = new PrintableList<int>(size);
            Random random = new Random();
            for (int i = 0; i < size; i++)
                result[i] = random.Next(size * 100);
            return result;
        }
    }
}
