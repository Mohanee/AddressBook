using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProblem
{
    class MultiDict
    {
        ABook a = new ABook();

        /// <summary>
        /// Initializing Dictionary to store all addressbooks
        /// </summary>
        Dictionary<string, List<Contact>> mdict = new Dictionary<string, List<Contact>>();


        /// <summary>
        /// Add new addressbook to dictionary
        /// </summary>
        /// <param name="key">name of the addressbook</param>
        /// <param name="list">AdressBook List of contacts</param>
        public void addNewAddressBook(string key, List<Contact> list)
        {
            mdict.Add(key, list);
        }

        /// <summary>
        /// Getter for Dictioanry
        /// </summary>
        public Dictionary<string,List<Contact>> getDictionary()
        {
            return this.mdict;
        }


        /// <summary>
        /// Displays contacts of all the AddressBooks 
        /// </summary>
        public void displayAllAddressBook()
        {
            foreach(KeyValuePair<string, List<Contact>> kvp in mdict)
            {
                Console.WriteLine("Address Book Number = {0}", kvp.Key);
                Console.WriteLine("Address Book Contents are : ");
                a.displayAll(kvp.Value);
            }
        }

        /// <summary>
        /// Searches contacts based on the given city
        /// </summary>
        /// <param name="city">city to search contacts from</param>
        /// <returns>List of Contacts belonging to given city</returns>
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

        /// <summary>
        /// Searches contacts based on the given state
        /// </summary>
        /// <param name="state">state to search contacts from</param>
        /// <returns>List of Contacts belonging to given state</returns>
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
    }
}
