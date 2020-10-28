using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace AddressBookProblem
{
    class ABook
    {
        List<Contact> aBook = new List<Contact>();

        /// <summary>
        /// Setting an addressBook
        /// </summary>
        /// <param name="addBook">list of contacts</param>
        public void setAddBook(List<Contact> addBook)
        {
            this.aBook = addBook;
        }

        /// <summary>
        /// Searches contacts based on the given city
        /// </summary>
        /// <returns>List of Contacts belonging to this addressBook</returns>
        public List<Contact> getAddBook()
        {
            return this.aBook;
        }

        /// <summary>
        /// Adds a contact to the list
        /// </summary>
        /// <param name="contact">Contact to be added</param>
        public void addContact(Contact contact)
        {
            aBook.Add(contact);
        }

        /// <summary>
        /// Displays all the contact in the list
        /// </summary>
        /// <param name="list">list to be displayed</param>
        public void displayAll(List<Contact> list)
        {
            foreach (Contact c in list)
            {
                displayContact(c);
                Console.WriteLine("**************");
            }

        }

        /// <summary>
        /// Searches for a contact with a given first and last name
        /// </summary>
        /// <param name="fname">first name to search</param>
        /// <param name="lname">last name to search</param>
        /// <returns>Contact with given first and last name</returns>
        public Contact SearchUsingName(string fname, string lname)
        {
            Contact cnew = null;
            foreach (Contact c in aBook)
            {
                if (c.getFirstName().Equals(fname) && c.getLastName().Equals(lname))
                {
                    cnew = c;
                    break;
                }
            }
            return cnew;
        }

        /// <summary>
        /// Edits details of a contact based on the choosen type
        /// </summary>
        /// <param name="c">Conatct to be edited</param>
        /// <param name="k">choosen field of option to edit</param>
        /// <returns>Returns the edited Contact</returns>
        public Contact editContact(Contact c, int k)
        {
            switch (k)
            {
                case 1:
                    Console.WriteLine("Enter the new First name");
                    string fname = Console.ReadLine();
                    c.setFirstName(fname);
                    break;

                case 2:
                    Console.WriteLine("Enter the new Last name");
                    string lname = Console.ReadLine();
                    c.setLastName(lname);
                    break;

                case 3:
                    Console.WriteLine("Enter the new Email");
                    string email = Console.ReadLine();
                    c.setEmail(email);
                    break;

                case 4:
                    Console.WriteLine("Enter the new Address");
                    string city = Console.ReadLine();
                    c.setCity(city);
                    break;

                case 5:
                    Console.WriteLine("Enter the new State");
                    string state = Console.ReadLine();
                    c.setState(state);
                    break;

                case 6:
                    Console.WriteLine("Enter the new phone number");
                    long pNum = long.Parse(Console.ReadLine());
                    c.setPhone(pNum);
                    break;

                default: break;
            }

            return (c);
        }

        /// <summary>
        /// Displays all the details of the contact
        /// </summary>
        /// <param name="c">Contact to be displayed</param>
        public void displayContact(Contact c)
        {
            Console.WriteLine("First Name : " + c.getFirstName());
            Console.WriteLine("Last Name : " + c.getLastName());
            Console.WriteLine("City : " + c.getCity());
            Console.WriteLine("State : " + c.getState());
            Console.WriteLine("Email : " + c.getEmail());
            Console.WriteLine("Phone Number : " + c.getPhone());
        }


        /// <summary>
        /// Deletes a contact from the list
        /// </summary>
        /// <param name="c">Contact to be deleted</param>
        public void deleteContact(Contact c)
        {
            aBook.Remove(c);
        }

        /// <summary>
        /// Checks if the same contact already exists in the list
        /// </summary>
        /// <param name="c1">Contact to be compared with all the contacts in the list</param>
        /// <returns>True if there's no duplicate found</returns>
        public bool CheckForDuplicate(Contact c1)
        {
            bool val = true;
            foreach (Contact c in aBook)
            {
              if(c1.Equals(c))
                {
                    val = false;
                }
            }
            return val;
        }

        /// <summary>
        /// Sorts the List in the order of name
        /// </summary>
        public void SortByName()
        {
            List<Contact> SortedList = aBook.OrderBy(o => o.getFirstName()).ToList();
            foreach(var Contact in SortedList)
            {
                Console.WriteLine(Contact.getFirstName() + "\t" + Contact.getLastName() + "\t" + Contact.getEmail() + "\t" + Contact.getPhone() + "\t" + Contact.getCity() + "\t" + Contact.getState());
            }  
        }

        /// <summary>
        /// Sorts the list in the order of City/State/Phone(k)
        /// </summary>
        /// <param name="k">choosen option in between city/state/phone</param>
        public void SortByAddress(int k)
        {

            if (k == 1)
            {
                List<Contact> SortedList = aBook.OrderBy(o => o.getCity()).ToList();
                foreach (var Contact in SortedList)
                {
                    Console.WriteLine(Contact.getFirstName() + "\t" + Contact.getLastName() + "\t" + Contact.getEmail() + "\t" + Contact.getPhone() + "\t" + Contact.getCity() + "\t" + Contact.getState());
                }
            }
            if(k==2)
            {
                List<Contact> SortedList = aBook.OrderBy(o => o.getState()).ToList();
                foreach (var Contact in SortedList)
                {
                    Console.WriteLine(Contact.getFirstName() + "\t" + Contact.getLastName() + "\t" + Contact.getEmail() + "\t" + Contact.getPhone() + "\t" + Contact.getCity() + "\t" + Contact.getState());
                }
            }
            if(k==3)
            {
                List<Contact> SortedList = aBook.OrderBy(o => o.getCity()).ToList();
                foreach (var Contact in SortedList)
                {
                    Console.WriteLine(Contact.getFirstName() + "\t" + Contact.getLastName() + "\t" + Contact.getEmail() + "\t" + Contact.getPhone() + "\t" + Contact.getCity() + "\t" + Contact.getState());
                }
            }

            else
            {
                Console.WriteLine("Enter a valid option");
            }
        }

    }
}
