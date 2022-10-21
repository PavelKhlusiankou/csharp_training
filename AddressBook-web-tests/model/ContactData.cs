using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        
        private string firstname;
        private string lastname = "";

        public ContactData(string name)
        {
            this.firstname = name;
        }

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode();
        }
        public override string ToString()
        {
            return "name" + FirstName;
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return FirstName.CompareTo(other.FirstName);
        }
        public string FirstName
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
    }
}
