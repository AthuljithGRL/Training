using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Newtonsoft.Json;
using Practice_2;

namespace Practise_2
{
    public class JsonReadClass 
    {
        List<byte> listByte1 = new List<byte>();
        //List<byte> listByte2 = new List<byte>();


        public void ReadJson()
        {
           

            string text = File.ReadAllText("C:\\Users\\GRL\\Downloads\\sample2.json");
            var Obj = JsonSerializer.Deserialize<JsonInputDataset>(text);

            string input1 = Obj.Input1;
            string [] arr1 = input1.Split(",");
           for( int i =0; i< arr1.Length; i++)
            {
                int val1 = Int32.Parse(arr1[i]);
                byte Byte1 = (byte)val1;
                listByte1.Add(Byte1);
            }
                
               

          
           


            string input2 = Obj.Input2;                                 //Input2
            string[] arr2 = input2.Split(",");
           for(int i=0; i<arr2.Length; i++)
            {
                int val2 = Int32.Parse(arr2[i]);
                byte Byte2 = (byte)val2;
                listByte1.Add(Byte2);
            }





            for (int i = 0; i < listByte1.Count; i++)
            {
                Console.Write(listByte1[i]);
            }
            Console.WriteLine();
           

        }
        
    }
}
