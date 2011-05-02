using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quicksort
{
    class Animal : Comparable
    {

       private string name;
       private int height = 0;
       private int weight = 0;

        //constructor
        public Animal() { }

        public Animal(string name, int height, int weight)
        {
            this.name = name;
            this.height = height;
            this.weight = weight;
        }

        //getter / setter
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Height
        {
            get;
            set;
        }

        int Weight { get; set; }

        //custom logic
        public override int compare(Comparable c1)
        {
            if (c1 is Animal)
            {
                Animal a = (Animal)c1;
                return name.CompareTo(a.Name);
            }
            else
            {
                throw new InvalidCastException();
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0} Height: {1} Weight: {2}", name, height, weight);
        }
    }
}
