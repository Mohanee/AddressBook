using System;

namespace AddressBookProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to Address Book");
            Console.WriteLine("Enter the details of the contact to be added sepetated by space");
            string alldata = Console.ReadLine();
            string[] sepData = alldata.Split(" ");
            Contact c1 = new Contact(sepData[0],sepData[1],sepData[2],sepData[3],long.Parse(sepData[4]));
            ABook a = new ABook();
            a.addContact(c1);
            Console.WriteLine("Contact successfully added \n Following are the details");
            a.displayAll();
        }
    }
}
