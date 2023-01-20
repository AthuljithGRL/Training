using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Collections;
using System.Runtime.ExceptionServices;
using System.IO;
using Practice_2;
using Newtonsoft.Json.Linq;

namespace Practice_2
{
   
    public class FileEngine
    { 
      
        List<byte> ListJson1 = new List<byte>();
        List<byte> ListJson2 = new List<byte>();

        List<byte> list = new List<byte>();
        public void GetFile(FileInfo path)
        {

            list.Clear();
           
            FileStream fs = new FileStream($"{path}", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            //br.Close();
            //fs.Close();

            for (int i = 0; i < bytes.Length; i++)
            {
                list.Add(bytes[i]);
            }

            ProcessFileData();


        }
        public void ReadBinary()
        {

            DirectoryInfo objDirectoryInfo = new DirectoryInfo(@"C:\Users\GRL\Downloads\Jith");
            //FileInfo[] allFiles = objDirectoryInfo.GetFiles("*.gpkt", SearchOption.TopDirectoryOnly);
            FileInfo[] scriptFiles = objDirectoryInfo.GetFiles("*.gpkt", SearchOption.AllDirectories);

            for (int i = 0; i < scriptFiles.Length; i++)
            {
                GetFile(scriptFiles[i]);
            }


        }
     
      

        public void ProcessFileData()
        {


            //for (int i = 0; i < listOfLists.Count; i++)
            //{

            //    byte n = listOfLists[i] switch
            //    {
            //        [1, 1, 0, 4, 1, 5, 1, 1,..] => 1,
            //        _ => 0,
            //    };
            //    Console.WriteLine(n);
            //}
            //1,1,0,4,1,5,1,1,..

            

            
                Console.WriteLine(list is [1, 1, 0, 4, 1, 5, 1, 1,..]);

            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.Write(String.Join(",", list[i]));
            //}
        }

        public void List_pattern()
        {
            

            //for (int i = 0; i < list.Count; i++)
            //{
                
                int temp = list switch
                {
                    [1, 1, 0, 4, 1, 5, 1, 1,..] => 1,
                    _ => 0,
                };
                Console.WriteLine(temp);
            //}




        }
        public void ReadJson()
        {
         

            string text = File.ReadAllText("C:\\Users\\GRL\\Downloads\\sample2.json");
            var Obj = JsonSerializer.Deserialize<JsonInputDataset>(text);

            string input1 = Obj.Input1;
            string[] arr1 = input1.Split(",");

            for (int i = 0; i < arr1.Length; i++)
            {
                byte Byte1 = Convert.ToByte(arr1[i]);               
                ListJson1.Add(Byte1);
            }



            string input2 = Obj.Input2;                                 //Input2
            string[] arr2 = input2.Split(",");
            for (int i = 0; i < arr2.Length; i++)
            {
                byte Byte2 = Byte.Parse(arr2[i]); 
                ListJson2.Add(Byte2);
            }
        }


        void CSVFile()
        {
            List<string> list1 = new List<string> { "one", "two", "three" };
            var csv = new StringBuilder();
            for (int i = 0; i < list1.Count; i++)
            {
                csv.Append(list1[i]);
                File.WriteAllText("D:\\Athuljith\\Book1.csv", csv.ToString());

            }
        }

      

        public static void Main(string[]args)
        {        
            FileEngine Obj1 = new FileEngine();
            Obj1.ReadBinary();
            
            Obj1.List_pattern();
            Obj1.ReadJson();
        }

    }
}


//"Input1": "255,255,255,255,255,255,255,255,255,112,3,85",
//"Input2": "255,255,255,255,255,255,255,255,255,112,19"
