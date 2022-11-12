using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Policy;
using LinqToDB.Mapping;

namespace AddressBook_web_tests
{
    [Table(Name = "addressbook")]
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
            return LastName.CompareTo(other.LastName);

            //if (object.ReferenceEquals(other, null))
            // {
            //    return 1;
            // }
            // return FirstName.CompareTo(other.FirstName);
        }
        [Column(Name = "firstname")]
        public string FirstName { get; set; }
        [Column(Name = "lastname")]
        public string LastName { get; set; }
        [Column(Name = "address")]
        public string Address { get; set; }
        [Column(Name = "home")]
        public string HomePhone { get; set; }
        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }
        [Column(Name = "work")]
        public string WorkPhone { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
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
        [Column(Name = "email")]
        public string Email { get; set; }
        [Column(Name = "email2")]
        public string Email2 { get; set; }
        [Column(Name = "email3")]
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
                    return (CleanUp2(Email) + CleanUp2(Email2) + CleanUp2(Email3 + "\r\n\r\n\r\n\r\n\r\n")).Trim();
                }

            }

            set
            {
                _AllEmails = value;
            }
        }
        private string _AllEmails;
        private string _AllPhones2;

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
                    return (CleanUp3(FirstName + LastName) + "\r\n" + CleanUp3(Address) + "\r\n" + "\r\n" + CleanUp3(AllPhones2) + "\r\n" + "\r\n" + CleanUp3(AllEmails).Trim());
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
            return Regex.Replace(data, "[ H:W:M:]", "");
        }
        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts select g).ToList();
            }
        }
        public string AllPhones2
        {
            get
            {
                if (_AllPhones2 != null)
                {
                    return _AllPhones2;
                }
                else
                {
                    return (CleanUp4(HomePhone) + CleanUp4(MobilePhone) + CleanUp4(WorkPhone)).Trim();
                }

            }

            set
            {
                _AllPhones2 = value;
            }
        }

        private string CleanUp4(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ ]", "") + "\r\n";

        }
    }
}
