using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Malafeev.Nsudotnet.JsonSerializer
{
    [Serializable]
    class TestClass
    {
        public int i = 10;
        public string s = "qwerty";
        public bool b = true; 

        [NonSerialized] public String ignore = "Error"; 

        public int[] arrayMember = {1,2,3,4,5};


        public List<String> list = new List<String>();

        public Dictionary<int, String> dictionary = new Dictionary<int, String>();

        public InnerTestClass innerTestClass = null;
        public InnerTestClass innerTestClass2 = new InnerTestClass();

        public TestClass() 
        {
            list.Add("fff");
            list.Add("dd");

            dictionary.Add(1,"Slark");
            dictionary.Add(2, "Naga");
            dictionary.Add(3, "SF");

        }
    }

    [Serializable]
    class InnerTestClass 
    {
        public int p = 10;
        public int[] happyNumbers = { 1, 2, 3, 4, 5 };
        public String happyString = "Q";
        [NonSerialized] public String sadString = "Don't push me";
    } 
}


