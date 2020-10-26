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
       // MultiDict md = new MultiDict();

        public void setAddBook(List<Contact> addBook)
        {
            this.aBook = addBook;
        }
        public List<Contact> getAddBook()
        {
            return this.aBook;
        }

        public void addContact(Contact c)
        {
            aBook.Add(c);
        }

        public void displayAll(List<Contact> l)
        {
            foreach (Contact c in l)
            {
                displayContact(c);
                Console.WriteLine("**************");
            }

        }

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

        public void displayContact(Contact c)
        {
            Console.WriteLine("First Name : " + c.getFirstName());
            Console.WriteLine("Last Name : " + c.getLastName());
            Console.WriteLine("City : " + c.getCity());
            Console.WriteLine("State : " + c.getState());
            Console.WriteLine("Email : " + c.getEmail());
            Console.WriteLine("Phone Number : " + c.getPhone());
        }

        public void deleteContact(Contact c)
        {
            aBook.Remove(c);
        }

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

        public void SortByName()
        {
            List<Contact> SortedList = aBook.OrderBy(o => o.getFirstName()).ToList();
            foreach(var Contact in SortedList)
            {
                Console.WriteLine(Contact.getFirstName() + "\t" + Contact.getLastName() + "\t" + Contact.getEmail() + "\t" + Contact.getPhone() + "\t" + Contact.getCity() + "\t" + Contact.getState());
            }  
        }

    }
}
