using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Policy;

namespace AddressBook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string fullData;


        public ContactData(string name)
        {
            FirstName = name;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return (FirstName + " " + LastName).GetHashCode();
        }
        public override string ToString()
        {
            return LastName + " " + FirstName;
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return FirstName.CompareTo(other.FirstName) & LastName.CompareTo(other.LastName);
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string AllPhones 
        {
            get
            {
                if(allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }

            }

            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ --()]", "") + "\r\n";
        }

        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string AllEmails
        {
            get
            {
                if (_AllEmails != null)
                {
                    return _AllEmails;
                }
                else
                {
                    return (CleanUp2(Email) + CleanUp2(Email2) + CleanUp2(Email3)).Trim();
                }

            }

            set
            {
               _AllEmails = value;
            }
        }
        private string _AllEmails;
             private string CleanUp2(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return Regex.Replace(email, "[ ]", "") + "\r\n";
        }
        public string FullData
        {
            get
            {
                if (fullData != null)
                {
                    return fullData;
                }
                else
                {
                    return (CleanUp3(FirstName + LastName) + "\r\n" + CleanUp3(Address) + "\r\n" + "\r\n" + CleanUp3("H:" + HomePhone) + "\r\n" + CleanUp3(MobilePhone) + CleanUp3("W:" + WorkPhone) + "\r\n" + CleanUp3(Email) + CleanUp3(Email2) + CleanUp3(Email3)).Trim();
                }

            }

            set
            {
                fullData = value;
            }
        }
        private string CleanUp3(string data)
        {
            if (data == null || data == "")
            {
                return "";
            }
            return Regex.Replace(data, "[ ]", "");
        }

    }
}
