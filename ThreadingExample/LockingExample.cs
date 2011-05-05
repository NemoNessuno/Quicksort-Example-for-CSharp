using System;
using System.Threading;

namespace ThreadingExample
{

    public class Test
    {
        //Wir deklarieren ein statisches ReadWriteLock
        static ReaderWriterLock rwl = new ReaderWriterLock();
        //Ein einfaches int als resource
        static int resource = 0;

        const int numThreads = 26;
        static bool running = true;
        static Random rnd = new Random();

        // Statistische werte auf die wir atomar schreiben
        static int reads = 0;
        static int writes = 0;
        static int writetimeouts = 0;

        public static void Main(string[] args)
        {
            //Starten der Threads
            //Wir übergeben ThreadProc als delegate
            Thread[] t = new Thread[numThreads];
            for (int i = 0; i < numThreads; i++)
            {
                t[i] = new Thread(ThreadProc);
                t[i].Name = "Thread" + Convert.ToString(i);
                t[i].Start();
                if (i > 10)
                    Thread.Sleep(30);
            }

            //Beende die Threads und warte dass sie fertig sind
            running = false;
            for (int i = 0; i < numThreads; i++)
            {
                t[i].Join();
            }

            Console.WriteLine("Reads: {0}, Writes: {1}, WriteTimeouts: {2}", reads, writes, writetimeouts);
        }

        static void ThreadProc()
        {
            //Sorgt dafür das zufällig gelesen oder geschrieben wird
            while (running)
            {
                double action = rnd.NextDouble();
                if (action < .8)
                    ReadFromResource(10);
                else if (action < 1)
                    WriteToResource(100);
            }
        }

        //Die Methode um von der Resource zu lesen
        static void ReadFromResource(int timeOut)
        {
            try
            {
                rwl.AcquireReaderLock(timeOut);
                try
                {
                    Console.WriteLine("Read from Resource. Value of Resource: {0}", resource);
                    Interlocked.Increment(ref reads);
                }
                finally
                {
                    //Wir geben das ReaderLock auf jeden Fall frei.
                    rwl.ReleaseReaderLock();
                }
            }
            catch (ApplicationException) { }
        }

        //Die Methode um auf die Resource zu schreiben.
        static void WriteToResource(int timeOut)
        {
            try
            {
                rwl.AcquireWriterLock(timeOut);
                try
                {
                    resource = rnd.Next(500);
                    Console.WriteLine("Written to Resource. Value of Resource: {0}", resource);
                    Interlocked.Increment(ref writes);
                }
                finally
                {
                    //Wir geben das WriteLock auf jeden Fall frei.
                    rwl.ReleaseWriterLock();
                }
            }
            catch (ApplicationException) {
                Interlocked.Increment(ref writetimeouts);
            }
        }
    }
}