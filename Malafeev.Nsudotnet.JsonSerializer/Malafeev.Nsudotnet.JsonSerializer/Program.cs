using System;

namespace Malafeev.Nsudotnet.JsonSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
           var testClass = new TestClass();
           Console.Write(Json.GetObject(testClass)); 
        }
    }
}
