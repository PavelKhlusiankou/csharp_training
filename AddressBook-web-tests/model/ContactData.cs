using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {


        public ContactData(string name)
        {
            FirstName = name;
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
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() & LastName.GetHashCode();
        }
        public override string ToString()
        {
            return "name=" + LastName + FirstName;
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return FirstName.CompareTo(other.FirstName) ;
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Id { get; set; }

    }

}
