using System;
using System.Threading;

namespace ThreadingExample
{
    class SyncEventExample
    {
        static AutoResetEvent autoEvent;
        static ManualResetEvent manualEvent;

        static void AutoDoWork()
        {
            Console.WriteLine("Warte auf AutoEvent");
            autoEvent.WaitOne();
            Console.WriteLine("AutoEvent erhalten");
        }

        static void ManualDoWork()
        {
            Console.WriteLine("Warte auf ManualEvent");
            manualEvent.WaitOne();
            Console.WriteLine("ManualEvent erhalten");
        }

        static void Main()
        {
            //AutoEvent
            autoEvent = new AutoResetEvent(false);
            new Thread(AutoDoWork).Start();

            Console.WriteLine("AutoWorker gestartet");
            Console.WriteLine("1 Sekunde schlafen");
            
            Thread.Sleep(1000);

            Console.WriteLine("AutoEvent gesetzt");
            autoEvent.Set();

            //ManualEvent
            manualEvent = new ManualResetEvent(false);
            for (int i = 0; i < 4; i++)
            new Thread(ManualDoWork).Start();

            Console.WriteLine("3 ManualWorker gestartet");
            Console.WriteLine("1 Sekunde schlafen");

            Thread.Sleep(1000);

            Console.WriteLine("ManualEvent gesetzt");
            manualEvent.Set();
        }
    }

}
