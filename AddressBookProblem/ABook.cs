using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProblem
{
    class ABook
    {
        private List<Contact> aBook = new List<Contact>();

        public void setAddBook(List<Contact> addBook)
        {
            this.aBook = addBook;
        }
        public List<Contact> getAddBook()
        {
            return aBook;
        }

    }
}
