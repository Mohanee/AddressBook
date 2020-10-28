using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProblem
{
    class Contact
    {
        public string fName { get; set; }
        public string lName { get; set; }
        public string email { get; set; }
        public string city { get; set; }

        public string state { get; set; }

        public long pNumber { get; set; }


        public Contact(string fName, string lName, string email, string city, string state, long pNumber)
        {
            this.fName = fName;
            this.lName = lName;
            this.email = email;
            this.pNumber = pNumber;
            this.city = city;
            this.state = state;
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

        public string getCity()
        {
            return this.city;
        }
        public void setCity(string city)
        {
            this.city = city;
        }

        public string getState()
        {
            return this.state;
        }
        public void setState(string state)
        {
            this.state = state;
        }


        public override bool Equals(object c)
        {
            if (c == null || (GetType() != c.GetType()))
            {
                return false;
            }
            Contact c2 = (Contact)c;

            return (fName == c2.getFirstName()) && (lName == c2.getLastName()) ;
        }

        public override string ToString() => fName +","+ lName + "," + email + "," +  city + "," + state + "," + pNumber;
    }
}
