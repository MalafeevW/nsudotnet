﻿using System;


namespace Malafeev.Nsudotnet.JsonSerializer
{
        [Serializable]
        class TestClass
        {
            public int i;
            public string s = "Hello";

            [NonSerialized]
            public string ignore; 

            public int[] arrayMember;

            
            public TestClass()
            {
                i = 25;
                s = "Hello";
                arrayMember = new int[5] { 1, 2, 3, 4, 5 };
                ignore = "Bay";
            }

        }
    
}
