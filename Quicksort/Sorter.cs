using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Quicksort
{

    abstract class Sorter
    {
       public abstract void Sort();
       public abstract void ConcurrentSort(int threadnumber);
    }

    class ComparableSorter : Sorter
    {
        dynamic[] comparables;
        protected Thread[] threadpool;

        public ComparableSorter(PrintableList list)
        {
            this.comparables = list.ts;
        }

        public override void Sort()
        {
            QuickSort(0, this.comparables.Count() - 1);
        }

        public override void ConcurrentSort(int threadnumber)
        {
            threadpool = new Thread[threadnumber];
            ConcurrentQuickSort(0, this.comparables.Count() - 1);
            foreach (Thread thread in threadpool)
            {
                thread.Join();
            }
        }

        protected void ConcurrentQuickSort(int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Divide(left, right);
                if (!SpaceForWorker(left, pivotIndex - 1))
                {
                    QuickSort(left, pivotIndex - 1);
                    QuickSort(pivotIndex + 1, right);
                }
                else if (!SpaceForWorker(pivotIndex + 1, right))
                {
                    QuickSort(pivotIndex + 1, right);
                }
            }
        }

        private bool SpaceForWorker(int left, int right)
        {
            for (int i = 0; i < threadpool.Length; i++)
            {
                if (threadpool[i] == null)
                {
                    SortingWorker worker = new SortingWorker(delegate()
                    {
                        ConcurrentQuickSort(left, right);
                    });
                    threadpool[i] = new Thread(new ThreadStart(worker.Work));
                    threadpool[i].Start();
                    return true;
                }
            }
            return false;
        }

        private void QuickSort(int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Divide(left, right);
                QuickSort(left, pivotIndex - 1);
                QuickSort(pivotIndex + 1, right);
            }
        }

        private int Divide(int left, int right)
        {
            int i = left;
            int j = right;
            dynamic pivot = comparables[right];
            do
            {
                while (comparables[i] <= pivot && i < right)
                    i++;
                while (comparables[j] >= pivot && j > left)
                    j--;

                if (i < j) swap(i, j);

            } while (i < j);

            if (comparables[i] > pivot)
                swap(i, right);

            return i;
        }

        private void swap(int i, int j)
        {
            dynamic temp = comparables[i];
            comparables[i] = comparables[j];
            comparables[j] = temp;
        }

        public class SortingWorker
        {
            DoWork dw;

            public delegate void DoWork();
            public SortingWorker(DoWork dw)
            {
                this.dw = dw;
            }

            public void Work()
            {
                dw();
            }
        }
    }

    //class IntSorter : Sorter
    //{

    //    private int[] value;

    //    public IntSorter(int[] value)
    //    {
    //        this.value = value;
    //    }

    //    public int[] Value { get { return this.value; } }

    //    public override void Sort()
    //    {
    //        QuickIntSort(0, this.value.Count() - 1);
    //    }

    //    public override void ConcurrentSort(int numberthreads) { }

    //    private void QuickIntSort(int left, int right)
    //    {
    //        if (left < right)
    //        {
    //            int pivotIndex = Divide(left, right);
    //            QuickIntSort(left, pivotIndex - 1);
    //            QuickIntSort(pivotIndex + 1, right);
    //        }
    //    }

    //    private int Divide(int left, int right)
    //    {
    //        int i = left;
    //        int j = right;
    //        int pivot = value[right];
    //        do
    //        {
    //            while (value[i] <= pivot && i < right)
    //                i++;
    //            while (value[j] >= pivot && j > left)
    //                j--;

    //            if (i < j) Swap(i, j);

    //        } while (i < j);

    //        if (value[i] > pivot)
    //            Swap(i, right);

    //        return i;
    //    }

    //    private void Swap(int i, int j)
    //    {
    //        int temp = value[i];
    //        value[i] = value[j];
    //        value[j] = temp;
    //    }
    //}
}
