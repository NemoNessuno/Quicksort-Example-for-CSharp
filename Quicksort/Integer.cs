using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quicksort
{
    class Integer : Comparable
    {

        private int zahl;
        public int Zahl { get { return zahl; } set { zahl = value; } }

        public override int compare(Comparable c1)
        {
            if (c1 is Integer)
            {
                Integer a = (Integer)c1;
                return zahl.CompareTo(a.Zahl);
            }
            else
            {
                throw new InvalidCastException();
            }
        }
    }
}
