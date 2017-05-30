using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Collections;

namespace Malafeev.Nsudotnet.JsonSerializer
{
    class JsonSerializer
    {

        public int Serialize(Object serializibedObject, Stream output) 
        {

            if (serializibedObject == null)
            {
                return 1;
            }

           
            Type t = serializibedObject.GetType();

            if (t.IsSerializable == false)
            {
                return 2;
            }


            Field[] objectFields = t.GetFields();

            try
            {
                  output.WriteLine("{");

                    foreach (Field object in objectFields)
                    {
                        var nonSerialized = objectField.Get(typeof(NonSerializedAttribute), false);

                        if (nonSerialized.Length == 0)     //если поле Serialised
                        {
                            var objectFieldValue = objectField.GetValue(serializibedObject);

                            if (objectField.FieldType.IsPrimitive)
                            {
                                output.Write(String.Format("\"{0}\": {1}", objectField.Name, objectFieldValue.ToString()));
                            }
                            else if (objectFieldValue is String)
                            {
                                output.Write(String.Format("\"{0}\": \"{1}\"", objectField.Name, objectFieldValue.ToString()));
                            }
                            else if (objectFieldValue is IEnumerable)
                            {
                                StringBuilder arrayString = new StringBuilder();
                                arrayString.Append(String.Format("\"{0}\": [", objectField.Name));
                                foreach (var value in (IEnumerable)objectFieldValue)
                                {
                                    arrayString.Append(value.ToString() + ",");
                                }
                                arrayString.Remove(arrayString.Length - 1, 1);
                                arrayString.Append("]");
                                output.Write(arrayString);
                            }
                            else 
                            {   
                                if(objectField.FieldType.IsSerializable)
                                {

                                    if (objectFieldValue == null)
                                    {
                                        output.Write(String.Format("\"{0}\": null", objectField.Name));
                                    }
                                    else
                                    {
                                        output.Write(String.Format("\"{0}\": ", objectField.Name));
                                        Serialize(objectFieldValue, output);
                                    }
                                }
                            }
                        }
                    }

                    output.Write("}");
                    output.Flush();
                    
            }
            catch (System.ArgumentException) 
            {
                Console.Write("incorrect output file name");
                Console.ReadKey(false);
            }
            return 0;
            
        }


    }
}
