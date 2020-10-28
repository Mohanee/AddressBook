using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.InteropServices.ComTypes;

namespace AddressBookProblem
{
    class Program
    {
        public static Dictionary<string, List<Contact>> cityDictionary = new Dictionary<string, List<Contact>>();
        public static Dictionary<string, List<Contact>> stateDictionary = new Dictionary<string, List<Contact>>();
        public static void Main(string[] args)
        {
            MultiDict md = new MultiDict();
            ABook a2 = new ABook();
            bool val1 = true;
            while (val1)
            {
                Console.WriteLine("Choose the following Operations:" +
                    "\n1.Create AddressBooks"+   
                    "\t2.Search Contacts By City(All AddrBooks)"+
                    "\t3.Search Contacts By State(All AddrBooks)"+    
                    "\t4.Read From File"+
                    "\t5.Write to File"   +   
                    "\t6.CSV Operations+" +
                    "\t7.JSON Operations"+
                    "\t8.Exit");
                int achoice = Convert.ToInt32(Console.ReadLine());
                switch (achoice)
                {
                    case 1:
                        {
                            Console.WriteLine("Hello, How many address books you want to create?");
                            int no_ABooks = Convert.ToInt32(Console.ReadLine());
                            for (int j = 0; j < no_ABooks; j++)
                            {
                                Console.WriteLine("Enter the name of address book");
                                String name = Console.ReadLine();
                                ABook a = new ABook();
                                bool val = true;
                                while (val)
                                {
                                    Console.WriteLine("\nHello, Welcome to Address Book " + name + 
                                        "\nChoose the operation you want to perform"+      
                                        "\n1.Add Contact"+     "\n2.Edit Contact"+      
                                        "\n3.Delete a contact from the list"+
                                        "\n4.Exit from operations"+     "\n5.Sort Entries by Person Name"+   
                                        "\n6.Sort Entries by Address");
                                    int choice = Convert.ToInt32(Console.ReadLine());

                                    switch (choice)
                                    {
                                        case 1:
                                            Console.WriteLine("\nAdd Contact\nHow many Contacts do you want to add ?");
                                            int n = Convert.ToInt32(Console.ReadLine());
                                            for (int i = 1; i <= n; i++)
                                            {
                                                Console.WriteLine("Enter the details of Contact " + i + " to be added separated by space");
                                                string alldata = Console.ReadLine();
                                                string[] sepData = alldata.Split(" ");
                                                Contact c1 = new Contact(sepData[0], sepData[1], sepData[2], sepData[3], sepData[4], long.Parse(sepData[5]));
                                                bool dupCheck = a.CheckForDuplicate(c1);
                                                if (dupCheck)
                                                {
                                                    a.addContact(c1);

                                                    if (!(cityDictionary.ContainsKey(sepData[3])))
                                                    {
                                                        List<Contact> cityList = new List<Contact>();
                                                        cityList.Add(c1);
                                                        cityDictionary.Add(sepData[3], cityList);
                                                    }
                                                    else
                                                    {
                                                        List<Contact> l = searchedContactDictionaryCity(sepData[3]);
                                                        l.Add(c1);
                                                    }


                                                    if (!(stateDictionary.ContainsKey(sepData[4])))
                                                    {
                                                        List<Contact> stateList = new List<Contact>();
                                                        stateList.Add(c1);
                                                        stateDictionary.Add(sepData[4], stateList);
                                                    }
                                                    else
                                                    {
                                                        List<Contact> l = searchedContactDictionaryState(sepData[3]);
                                                        l.Add(c1);
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Cannot add Contact as Contact with same name already exists");
                                                }
                                            }
                                            Console.WriteLine("Contact successfully added...........Following are the details\n");
                                            a.displayAll(a.getAddBook());
                                            break;

                                        case 2:
                                            Console.WriteLine("Enter the first and last name of the contact seperated by space");
                                            String edata1 = Console.ReadLine();
                                            string[] edata = edata1.Split(" ");
                                            Contact c = a.SearchUsingName(edata[0], edata[1]);
                                            if (c == null)
                                            {
                                                Console.WriteLine("No such contacts found....Please enter correct input");
                                                break;
                                            }
                                            Console.WriteLine("Following are the present details of the contact you chose to edit");
                                            a.displayContact(c);
                                            Console.WriteLine("Choose which detail you want to edit\n1.First Name\t2.Last Name\t3.Email\t4.City\t5.State\t6.Phone number");
                                            int m = Convert.ToInt32(Console.ReadLine());
                                            Contact cEdited = a.editContact(c, m);
                                            Console.WriteLine("Here are the updated details");
                                            a.displayContact(cEdited);
                                            break;

                                        case 3:
                                            Console.WriteLine("Enter the first and last name of the contact you want to delete");
                                            String ddata1 = Console.ReadLine();
                                            string[] ddata = ddata1.Split(" ");
                                            Contact cDel = a.SearchUsingName(ddata[0], ddata[1]);
                                            if (cDel == null)
                                            {
                                                Console.WriteLine("No such contacts found....Please enter correct input");
                                                break;
                                            }
                                            a.deleteContact(cDel);
                                            Console.WriteLine("Contact successfully deleted\nFollowing is the contact list\n");
                                            a.displayAll(a.getAddBook());
                                            break;

                                        case 4:
                                            val = false;
                                            break;

                                        case 5:
                                            a.SortByName();
                                            break;

                                        case 6:
                                            Console.WriteLine("Which criteria do you want to Sort?\n1.City\t2.State\t3.Phone");
                                            int asort = Convert.ToInt32(Console.ReadLine());
                                            a.SortByAddress(asort);
                                            break;

                                        default: break;

                                    }
                                }
                                md.addNewAddressBook(name, a.getAddBook());
                            }
                            md.displayAllAddressBook();
                            break;
                        }

                    case 2:
                        {
                            if (cityDictionary.Count != 0)
                            {
                                Console.WriteLine("Enter the city name");
                                string city = Console.ReadLine();
                                List<Contact> l1 = new List<Contact>();
                                foreach (KeyValuePair<string, List<Contact>> kvp in cityDictionary)
                                {
                                    if (kvp.Key == city)
                                    {
                                        l1 = kvp.Value;
                                        break;
                                    }
                                }
                                if (l1 != null)
                                {
                                    Console.WriteLine("Following are the details of contacts who belong to " + city + "\n");
                                    a2.displayAll(l1);
                                    Console.WriteLine("Total number of persons belonging to this city is : " + l1.Count);
                                }
                                else
                                {
                                    Console.WriteLine("No Person belongs to that city");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Empty AddressBook, first enter the contacts");
                            }
                            break;
                        }

                    case 3:
                        {
                            if (stateDictionary.Count != 0)
                            {
                                Console.WriteLine("Enter the state name");
                                string state = Console.ReadLine();
                                List<Contact> l2 = new List<Contact>();
                                foreach (KeyValuePair<string, List<Contact>> kvp in stateDictionary)
                                {
                                    if (kvp.Key == state)
                                    {
                                        l2 = kvp.Value;
                                        break;
                                    }
                                }
                                if (l2 != null)
                                {
                                    Console.WriteLine("Following are the details of contacts who belong to " + state + "\n");
                                    a2.displayAll(l2);
                                    Console.WriteLine("Total number of persons belonging to this state is : " + l2.Count);
                                }
                                else
                                {
                                    Console.WriteLine("No Person belongs to that state");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Empty AddressBook, first enter the contacts");
                            }
                            break;
                        }
                    case 4:
                        FileIO.ReadFromFile();
                        break;
                    case 5:
                        FileIO.WriteToFile(md.getDictionary());
                        break;
                    case 6: val1 = false;
                        break;

                    case 7:
                        bool csvVal = true;
                        while (csvVal)
                        {
                            Console.WriteLine("Choose CSV operation\n1.Write to CSV File\t2.Read from CSV File\t3.Copy one csv to other\t4.Exit");
                            int kCSV = Convert.ToInt32(Console.ReadLine());
                            switch (kCSV)
                            {
                                case 1: FileIO.WriteToCSVFile(md.getDictionary());
                                    break;

                                case 2: FileIO.ReadFromCSVFile();
                                    break;

                                case 3: FileIO.ImplementCSVDataHandling();
                                    break;

                                case 4:
                                    csvVal = false;
                                    break;

                                default:
                                    break;
                            }
                        }
                        break;

                    case 8:
                        bool jsonVal = true;
                        while(jsonVal)
                        {
                            Console.WriteLine("Choose JSON operation\n1.Write to JSON file\t 2.Read from JSON file \t 3.Exit");
                            int kJSON = Convert.ToInt32(Console.ReadLine());
                            switch(kJSON)
                            {
                                case 1:
                                    FileIO.WriteToJSONFile(md.getDictionary());
                                    break;

                                case 2:
                                    FileIO.ReadFromJSONFile();
                                    break;

                                case 3:
                                    jsonVal = false;
                                    break;

                                default:
                                    break;
                            }
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    
        /// <summary>
        /// Searches all the addressbooks in a dictionary for contacts belonging to a city 
        /// </summary>
        /// <param name="city">city name to be searched for</param>
        /// <returns>list of contacts which belong to one city</returns>
        public static List<Contact> searchedContactDictionaryCity(string city)
        {
            List<Contact> l2 = new List<Contact>();
            foreach (KeyValuePair<string, List<Contact>> kvp in cityDictionary)
            {
                if (kvp.Key == city)
                {
                    l2 = kvp.Value;
                    break;
                }
            }
            return l2;
        }

        /// <summary>
        /// Searches all the addressbooks in a dictionary for contacts belonging to a state
        /// </summary>
        /// <param name="state">state name to be searched for</param>
        /// <returns>list of contacts which belong to one state</returns>
        public static List<Contact> searchedContactDictionaryState(string state)
        {
            List<Contact> lSearched2 = new List<Contact>();
            foreach (KeyValuePair<string, List<Contact>> kvp in stateDictionary)
            {
                if (kvp.Key == state)
                {
                    lSearched2 = kvp.Value;
                    break;
                }
            }
            return lSearched2;

        }

    }

}

