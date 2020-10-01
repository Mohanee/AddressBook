using System;

namespace AddressBookProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            ABook a = new ABook();
            Console.WriteLine("Hello, Welcome to Address Book \nAdd Contact\nHow many Contacts do you want to add?");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <=n; i++)
            {
                Console.WriteLine("Enter the details of Contact "+i+" to be added sepetated by space");
                string alldata = Console.ReadLine();
                string[] sepData = alldata.Split(" ");
                Contact c1 = new Contact(sepData[0], sepData[1], sepData[2], sepData[3], long.Parse(sepData[4]));
                a.addContact(c1);
            }
            Console.WriteLine("Contact successfully added...........Following are the details");
            a.displayAll();
        }
    }
}
