using System;
using System.Threading;

class Test
{
    static void DoTest()
    {
        //Aufruf der statischen Methode ohne Parameter
        Thread newThread = new Thread(Work.DoWork);
        newThread.Start();

        //Wir Instanziieren ein Worker-Objekts
        //und übergeben die Daten an seinen Member
        Work w = new Work();
        w.Data = 42;
        newThread = new Thread(w.DoMoreWork);
        newThread.Start();

        //Aufruf der statischen Methode DoParamWork
        //mit Übergabe von Parametern
        newThread = new Thread(Work.DoParamWork);
        newThread.Start(42);

        //Aufruf der Instanzmethode DoMoreParamWork
        //mit Übergabe von Parametern
        newThread = new Thread(w.DoMoreParamWork);
        newThread.Start("The answer.");
    }
}

class Work
{
    public int Data;

    public static void DoWork()
    {
        Console.WriteLine("Static thread procedure.");
    }

    public void DoMoreWork()
    {
        Console.WriteLine("Instance thread procedure. Data={0}", Data);
    }

    public static void DoParamWork(object data)
    {
        Console.WriteLine("Static thread procedure. Data='{0}'",
                data);
    }

    public void DoMoreParamWork(object data)
    {
        Console.WriteLine("Instance thread procedure. Data='{0}'",
                data);
    }
}