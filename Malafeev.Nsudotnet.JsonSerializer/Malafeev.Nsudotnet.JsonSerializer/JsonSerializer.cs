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

        public int Serialize(Object serializibed, Stream output) 
        {

            if (serializibedObject == null)
            {
                return 1;
            }

           
            Type t = serializibed.GetT();

            if (t.IsSerializable == false)
            {
                return 2;
            }


            Field[] objectFields = t.GetF();

            try
            {
                  output.Write("{");

                    foreach (Field object in objectF)
                    {
                        var nonSerialized = objectF.Get(typeof(NonSerialize), false);

                        if (nonSerialized.Length == 0)     //если поле Serialised
                        {
                            var objectFV = objectF.Get(serializibed);

                            if (objectF.Field.IsPrimitive)
                            {
                                output.Write(String.Format("\"{0}\": {1}", objectF.Name, objectFV.ToString()));
                            }
                            else if (objectFV is String)
                            {
                                output.Write(String.Format("\"{0}\": \"{1}\"", objectF.Name, objectFV.ToString()));
                            }
                            else if (objectFV is IEnumerable)
                            {
                                StringB arrayS = new StringB();
                                arrayS.Append(String.Format("\"{0}\": [", objectF.Name));
                                foreach (var value in (IEnumerable)objectFV)
                                {
                                    arrayS.Append(value.ToString() + ",");
                                }
                                arrayS.Remove(arrayS.Length - 1, 1);
                                arrayS.Append("]");
                                output.Write(arrayS);
                            }
                            else 
                            {   
                                if(objectF.FieldT.IsSerializable)
                                {

                                    if (objectFV == null)
                                    {
                                        output.Write(String.Format("\"{0}\": null", objectF.Name));
                                    }
                                    else
                                    {
                                        output.Write(String.Format("\"{0}\": ", objectF.Name));
                                        Serialize(objectFV, output);
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
