using System;

namespace Quicksort
{
    abstract class Comparable
    {
       public abstract int compare(Comparable c1);
    
    public static bool operator <=(Comparable c1, Comparable c2)
        {
            return c1.compare(c2) <= 0;
        }

        public static bool operator >=(Comparable c1, Comparable c2)
        {
            return c1.compare(c2) >= 0;
        }

        public static bool operator <(Comparable c1, Comparable c2)
        {
            return c1.compare(c2) < 0;
        }

        public static bool operator >(Comparable c1, Comparable c2)
        {
            return c1.compare(c2) > 0;
        }
    }
}
