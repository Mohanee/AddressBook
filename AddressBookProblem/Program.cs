﻿using System;
using System.Collections.Generic;

namespace AddressBookProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiDict md = new MultiDict();
            Console.WriteLine("Hello, How many address books you want to create?");
            int no_ABooks = Convert.ToInt32(Console.ReadLine());
            ABook a2 = new ABook();
            for (int j = 0; j < no_ABooks; j++)
            {
                Console.WriteLine("Enter the name of address book");
                String name = Console.ReadLine();
                ABook a = new ABook();
                bool val = true;
                while (val)
                {
                    Console.WriteLine("\nHello, Welcome to Address Book "+name+"\nChoose the operation you want to perform\n1.Add Contact\n2.Edit Contact\n3.Delete a contact from the list\n4.Exit from operations");
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


                        default: break;

                    }
                }
                md.addNewAddressBook(name,a.getAddBook());
            } 
            md.displayAllAddressBook();

            Console.WriteLine("Do you want to search for a contact?? 1.Yes\t 2.No");
            int k = Convert.ToInt32(Console.ReadLine());
            if(k==1)
            {
                Console.WriteLine("Choose the criteria to search for \n1.City\t2.State");
                int s = Convert.ToInt32(Console.ReadLine());
                if (s == 1)
                {
                    Console.WriteLine("Enter the city name");
                    string city = Console.ReadLine();
                    List<Contact> l1 = md.searchedContactListCity(city);
                    if (l1 != null)
                    {
                        Console.WriteLine("Following are the details of contacts who belong to " + city);
                        a2.displayAll(l1);
                    }
                    else
                    {
                        Console.WriteLine("No Person belongs to that city");
                    }
                }
                else
                {
                    Console.WriteLine("Enter the state name");
                    string state = Console.ReadLine();
                    List<Contact> l2 = md.searchedContactListState(state);
                    if (l2 != null)
                    {
                        Console.WriteLine("Following are the details of contacts who belong to " + state);
                        a2.displayAll(l2);
                    }
                    else
                    {
                        Console.WriteLine("No Person belongs to that state");
                    }
                }
            }
        }
    }
}
