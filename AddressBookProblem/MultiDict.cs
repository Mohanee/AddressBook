using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProblem
{
    class MultiDict
    {
        Dictionary<int, List<Contact>> mdict = new Dictionary<int, List<Contact>>();
        //Contact c= new Contact()
        ABook a = new ABook();

        public void addNewAddressBook(int key, List<Contact> list)
        {
            mdict.Add(key, list);
        }

        public void displayAllAddressBook()
        {
            foreach(KeyValuePair<int, List<Contact>> kvp in mdict)
            {
                Console.WriteLine("Address Book Number = {0}", kvp.Key);
                Console.WriteLine("\t Address Book Contents are : "); 
                a.displayAll(kvp.Value);

            }
        }
    }
}
