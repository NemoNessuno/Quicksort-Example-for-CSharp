using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quicksort
{
    class PrintableList
    {
        public dynamic[] ts;

        public PrintableList(int size)
        {
            this.ts = new dynamic[size];
        }

        //Indexer Definition
        public dynamic this[int i]
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
            foreach (dynamic t in ts) Console.WriteLine(t);
        }
    }
}
