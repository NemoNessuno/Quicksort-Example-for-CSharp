using System;

//Sehr nützlich um warnings,die man
//ignorieren will zu unterdrücken
#pragma warning disable

namespace ExampleNameSpace
{
   abstract class ExampleClass
   {
       //Dieser int kann von überall gesehen werden
       public int integer1;

       //Dieser unsignend 32-bit int kann nur in dieser
       //Klasse oder Kindklassen gesehen werden
       protected uint uint1;

       //Dieser boolean kann von allen Klassen im Projekt
       //gesehen werden.
       internal bool boolean1;

       //Dieser char kann von allen Klassen im Projekt
       //und von allen Kindklassen gesehen werden.
       protected internal char char1;

       //Beide Member können nur in dieser Klasse 
       //gesehen werden. Klassmember sind per
       //default private.
       private byte byte1;
       string string1;

       string ExampleMethod1() { return ""; }

       public int ExampleMethod2(int param1)
       {
           return param1;
       }
       public int ExampleMethod2(string param1) { return param1.Length; }
       //Dies ist nicht möglich.
       //Methoden mit gleichem Namen müssen sich in ihren
       //Parametern unterscheiden
       //public string ExampleMethod2(string param1);

       public abstract void ExampleMethod3(int param1);

   }
}
