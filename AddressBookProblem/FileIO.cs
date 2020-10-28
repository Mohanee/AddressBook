using System;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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

    }
}

