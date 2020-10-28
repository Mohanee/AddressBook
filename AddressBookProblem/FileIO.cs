using System;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace AddressBookProblem
{
    class FileIO
    {
        /// <summary>
        /// Reads data from a .txt file
        /// </summary>
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

        /// <summary>
        /// Writes contacts from all addressbooks to a .txt file
        /// </summary>
        /// <param name="mdict">Dictionary of AddressBooks</param>
        public static void WriteToFile(Dictionary<string,List<Contact>> mdict)
        {
            string writeFile = @"C:\Users\RAJAT-DAMMU\Desktop\GitProjects\AddressBook\AddressBookProblem\ContactBook.txt";
           
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

        /// <summary>
        /// Writes contacts from all addressbooks to a .csv file
        /// </summary>
        /// <param name="mdict">Dictionary of AddressBooks</param>
        public static void WriteToCSVFile(Dictionary<string, List<Contact>> mdict)
        {
            string writeFile = @"C:\Users\RAJAT-DAMMU\Desktop\GitProjects\AddressBook\AddressBookProblem\ContactBookCSV.csv";
            if (File.Exists(writeFile))
            {
                using (var writer = new StreamWriter(writeFile))
                    using(var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        var records = new List<Contact>();
                        Console.WriteLine("Data written successfully");
                        foreach (KeyValuePair<string, List<Contact>> kvp in mdict)
                        {
                                 var record = kvp.Value.ToList();
                                 csvWriter.WriteRecords(record);
                                 csvWriter.NextRecord();
              
                        }
                    }
                    
            }
                else
                {
                    Console.WriteLine("No file");
                }
           
        }

        /// <summary>
        /// Reads data from a .csv file
        /// </summary>
        public static void ReadFromCSVFile()
        {
            string readFile = @"C:\Users\RAJAT-DAMMU\Desktop\GitProjects\AddressBook\AddressBookProblem\ContactBookCSV.csv";
            if (File.Exists(readFile))
            {
               using(var reader = new StreamReader(readFile))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Configuration.HeaderValidated = null;
                        var records = csv.GetRecords<Contact>().ToList();
                        Console.WriteLine("Data Read Successfully");
                        foreach(Contact c in records)
                        {
                            Console.WriteLine(c.getFirstName() + "\t" +c.getLastName() + "\t" + c.getEmail() + "\t"  +
                                "\t" + c.getCity() + "\t" + c.getState() + "\t" + c.getPhone());
                        }
                    }
            }
            else
            {
                Console.WriteLine("No file");
            }
        }

        /// <summary>
        /// Copies Data from one .csv file to other .csv file
        /// </summary>
        public static void ImplementCSVDataHandling()
        {
            string exportFilePath = @"C:\Users\RAJAT-DAMMU\Desktop\GitProjects\AddressBook\AddressBookProblem\ContactBookCSVCopy.csv";
            string importFilePath = @"C:\Users\RAJAT-DAMMU\Desktop\GitProjects\AddressBook\AddressBookProblem\ContactBookCSV.csv";
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Contact>().ToList();
                Console.WriteLine("Data Read Successfully");
                foreach (Contact c in records)
                {
                    Console.Write(c.getFirstName());
                    Console.Write("\t" + c.getLastName());
                    Console.Write("\t" + c.getEmail());
                    Console.Write("\t" + c.getPhone());
                    Console.Write("\t" + c.getCity());
                    Console.Write("\t" + c.getState());
                    Console.WriteLine("\n");
                }


                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
            }

        }

        /// <summary>
        /// Writes contacts from all addressbooks to a .json file
        /// </summary>
        /// <param name="mdict">Dictionary of AddressBooks</param>
        public static void WriteToJSONFile(Dictionary<string, List<Contact>> mdict)
        {
            string writeFile = @"C:\Users\RAJAT-DAMMU\Desktop\GitProjects\AddressBook\AddressBookProblem\ContactBookJSON.json";
            if (File.Exists(writeFile))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                using (var writer = new StreamWriter(writeFile))
                using (var jsonWriter = new JsonTextWriter(writer))
                {
                    var records = new List<Contact>();
                    Console.WriteLine("Data written successfully");
                    foreach (KeyValuePair<string, List<Contact>> kvp in mdict)
                    {
                        var record = kvp.Value.ToList();
                        jsonSerializer.Serialize(jsonWriter,record);
                        

                    }
                }

            }
            else
            {
                Console.WriteLine("No file");
            }

        }

        /// <summary>
        /// Reads data from a .json file
        /// </summary>
        public static void ReadFromJSONFile()
        {
            string readFile = @"C:\Users\RAJAT-DAMMU\Desktop\GitProjects\AddressBook\AddressBookProblem\ContactBookJSON.json";
            if (File.Exists(readFile))
            {
                using (var reader = new StreamReader(readFile))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    IList<Contact> records = JsonConvert.DeserializeObject<IList<Contact>>(File.ReadAllText(readFile));
                    foreach (Contact c in records)
                    {
                        Console.WriteLine(c.getFirstName() + "\t" + c.getLastName() + "\t" + c.getEmail() + "\t" +
                            "\t" + c.getCity() + "\t" + c.getState() + "\t" + c.getPhone());
                    }
                }
            }
            else
            {
                Console.WriteLine("No file");
            }
        }

    }
}

