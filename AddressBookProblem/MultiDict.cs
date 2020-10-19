using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProblem
{
    class MultiDict
    {
        ABook a = new ABook();
        Dictionary<string, List<Contact>> mdict = new Dictionary<string, List<Contact>>();
        

        public void addNewAddressBook(string key, List<Contact> list)
        {
            mdict.Add(key, list);
        }

        public Dictionary<string,List<Contact>> getDictionary()
        {
            return this.mdict;
        }

        public void displayAllAddressBook()
        {
            foreach(KeyValuePair<string, List<Contact>> kvp in mdict)
            {
                Console.WriteLine("Address Book Number = {0}", kvp.Key);
                Console.WriteLine("Address Book Contents are : ");
                a.displayAll(kvp.Value);
            }
        }


        public List<Contact> searchedContactListCity(string city)
        {
            List<Contact> lSearched = new List<Contact>();
            foreach (KeyValuePair<string, List<Contact>> kvp in mdict)
            {
                foreach (Contact c in kvp.Value)
                {
                    if (city.Equals(c.getCity()))
                    {
                        lSearched.Add(c);
                    }
                }
            }
            return lSearched;
        }

        public List<Contact> searchedContactListState(string state)
        {
            List<Contact> lSearched2 = new List<Contact>();
            foreach (KeyValuePair<string, List<Contact>> kvp in mdict)
            {
                foreach (Contact c in kvp.Value)
                {
                    if (state.Equals(c.getState()))
                    {
                        lSearched2.Add(c);
                    }
                }
            }
            return lSearched2;
        }

        //public List<Contact> 
    }
}
