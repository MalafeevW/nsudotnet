using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Malafeev.Nsudotnet.JsonSerializer
{
    class Program
    {

        public static void Main(String[] args)
        {
            Test test = new Test();
            JsonSerializer jsonSerializer = new JsonSerializer();
            using (Stream output = new Stream("output.txt"))
            {
                int check = jsonSerializer.Serialize(testClass, output);
                switch (check)
                {
                    case 0:
                        Console.Write("Successful serialize");
                        break;
                    case 1:
                        Console.Write("Serialized object is null");
                        break;
                    case 2:
                        Console.Write("Object, you want to serialize, not serializible");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
