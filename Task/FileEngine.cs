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

        public string path = @"D:\\Athuljith\\MyTest3.csv";
        public  string delimiter = ", ";

        List<byte> JsonList_Input1 = new List<byte>();
        List<byte> JsonList_Input2 = new List<byte>();
        List<byte> BinaryList = new List<byte>();
        
        public void GetFile(FileInfo path)
        {

            BinaryList.Clear();

            FileStream fs = new FileStream($"{path}", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
          

            for (int i = 0; i < bytes.Length; i++)
            {
                BinaryList.Add(bytes[i]);
            }

        }

        public void ProcessFileData()
        {



            //Input 1
            List<byte> matchList = BinaryList.Intersect(JsonList_Input1).ToList();

            int count = 0;
            List<int> positions = new List<int>();


            for (int i = 0; i < BinaryList.Count - JsonList_Input1.Count; i++)
            {
                if (BinaryList.GetRange(i, JsonList_Input1.Count).SequenceEqual(JsonList_Input1))
                {
                    count++;
                    positions.Add(i);
                }
            }

            Console.WriteLine("Number of occurrences of First Input: " + count);
            Console.WriteLine("Index positions: " + string.Join(", ", positions));

            //CSV File write
            string appendText = "Input 1" + delimiter + $"{count}" + delimiter + $"{string.Join(" ", positions)}" + delimiter + Environment.NewLine;
            File.AppendAllText(path, appendText);
            string readText = File.ReadAllText(path);
            Console.WriteLine(readText);


            //Input2
            List<byte> matchList2 = BinaryList.Intersect(JsonList_Input2).ToList();

            int count2 = 0;
            List<int> positions2 = new List<int>();


            for (int i = 0; i < BinaryList.Count - JsonList_Input2.Count; i++)
            {
                if (BinaryList.GetRange(i, JsonList_Input2.Count).SequenceEqual(JsonList_Input2))
                {
                    count2++;
                    positions2.Add(i);
                }
            }

            Console.WriteLine("Number of occurrences of Second Input: " + count2);
            Console.WriteLine("Index positions: " + string.Join(", ", positions2));

            //CSV File write for Input 2
            string appendText2 = "Input 2" + delimiter + $"{count2}" + delimiter + $"{string.Join(" ", positions2)}" + delimiter + Environment.NewLine;
            File.AppendAllText(path, appendText2);
            string readText2 = File.ReadAllText(path);
            Console.WriteLine(readText2);

        }



        public void CSVFile()
        {
            //CSV file header creation
            string createText = "Inputs" + delimiter + "Number of occurrences" + delimiter + "Address" + delimiter + Environment.NewLine;
            File.WriteAllText(path, createText);
        }

        public void ReadJson()
        {
           

            string text = File.ReadAllText("D:\\Data\\Task\\Json file.json");
            var Obj = JsonSerializer.Deserialize<JsonInputDataset>(text);

            string input1 = Obj.Input1;
            string[] arr1 = input1.Split(",");

            for (int i = 0; i < arr1.Length; i++)
            {
                byte Byte1 = Convert.ToByte(arr1[i]);
                JsonList_Input1.Add(Byte1);
            }



            string input2 = Obj.Input2;                                 //Input2
            string[] arr2 = input2.Split(",");
            for (int i = 0; i < arr2.Length; i++)
            {
                byte Byte2 = Convert.ToByte(arr2[i]);
                JsonList_Input2.Add(Byte2);
            }
        }

        public static void Main(string[] args)
        {
            

            FileEngine Obj1 = new FileEngine();
            Obj1.CSVFile();
            Obj1.ReadJson();

            //read the binary files one-by-one and then process
            DirectoryInfo objDirectoryInfo = new DirectoryInfo(@"D:\Data\Task\Binary files");
            FileInfo[] scriptFiles = objDirectoryInfo.GetFiles("*.gpkt", SearchOption.AllDirectories);

            for (int i = 0; i < scriptFiles.Length; i++)
            {
                Obj1.GetFile(scriptFiles[i]);
                Obj1.ProcessFileData();
               
            }
  
        }

    }
}
//string path = @"D:\\Athuljith\\MyTest.csv";

//// Set the variable "delimiter" to ", ".
//string delimiter = ", ";

//// This text is added only once to the file.
//if (!File.Exists(path))
//{
//    // Create a file to write to.
//    string createText = "Column 1 Name" + delimiter + "Column 2 Name" + delimiter + "Column 3 Name" + delimiter + Environment.NewLine;
//    File.WriteAllText(path, createText);
//}

//// This text is always added, making the file longer over time
//// if it is not deleted.
//string appendText = "This is text for Column 1" + delimiter + "This is text for Column 2" + delimiter + "This is text for Column 3" + delimiter + Environment.NewLine;
//File.AppendAllText(path, appendText);

//// Open the file to read from.
//string readText = File.ReadAllText(path);
//Console.WriteLine(readText);

//input 3 :111 187 133 126 37 170 129 170 127 168                  255,255,255,255,255,255,255,255,255,112,19
// input 4: 111,180,116,236,154,08,131,76,190,244
//Input 5 : 175,233,151,241,103
