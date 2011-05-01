using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quicksort
{
    class PrintableList<T>
    {
        public T[] ts;

        public PrintableList(int size)
        {
            this.ts = new T[size];
        }

        //Indexer Definition
        public T this[int i]
        {
            get
            {
                return ts[i];
            }
            set
            {
                ts[i] = value;
            }
        }

        public void Print()
        {
            foreach (T t in ts) Console.WriteLine(t);
        }
    }
}
