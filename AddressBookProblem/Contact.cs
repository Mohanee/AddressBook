using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProblem
{
    class Contact
    {
        protected string fName, lName, email, address;
        protected long pNumber;

        public Contact(string fName, string lName, string email, string address, long pNumber)
        {
            this.fName = fName;
            this.lName = lName;
            this.email = email;
            this.address = address;
            this.pNumber = pNumber;
        }

        public string getFirstName()
        {
            return this.fName;
        }
        public void setFirstName(string fName)
        {
            this.fName = fName;   
        }

        public string getLastName()
        {
            return this.lName;
        }
        public void setLastName(string lName)
        {
            this.lName = lName;
        }

        public string getAddress()
        {
            return this.address;
        }
        public void setAddress(string add)
        {
            this.address = add;
        }

        public string getEmail()
        {
            return this.email;
        }
        public void setEmail(string email)
        {
            this.email = email;
        }

        public long getPhone()
        {
            return this.pNumber;
        }
        public void setPhone(long pno)
        {
            this.pNumber = pno;
        }

    }
}
