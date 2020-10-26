using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddressBookProblem
{
    class FileIO
    {
        public static void ReadFromFile()
        {
            string readFile = @"C:\Users\RAJAT-DAMMU\Desktop\GitProjects\AddressBook\AddressBookProblem\ContactBook.txt";
            if (File.Exists(readFile))
            {
                using (StreamReader sr = File.OpenText(readFile))
                {
                    String fileData = "";
                    while ((fileData = sr.ReadLine()) != null)
                        Console.WriteLine((fileData));
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No file");
            }
        }

        public static void WriteToFile(Dictionary<string,List<Contact>> mdict)
        {
            string writeFile = @"C:\Users\RAJAT-DAMMU\Desktop\GitProjects\AddressBook\AddressBookProblem\ContactBook.txt";
            if(File.Exists(writeFile))
            {
                if (File.Exists(writeFile))
                {
                    using (StreamWriter streamWriter = File.AppendText(writeFile))
                    {
                        foreach (KeyValuePair<string, List<Contact>> kvp in mdict)
                        {
                            foreach (Contact c in kvp.Value)
                            {
                                streamWriter.WriteLine(c.getFirstName() + "," + c.getLastName() + "," +c.getEmail() + "," + c.getCity() + "," + c.getState()+","+c.getPhone());
                            }
                            streamWriter.Close();
                        }
                    }
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("No file");
                }
            }
        }
    }
}
