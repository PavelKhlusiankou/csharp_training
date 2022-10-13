﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_web_tests
{
    public class ContactData
    {
        
        private string firstname;
        private string lastname = "";

        public ContactData(string name)
        {
            this.firstname = name;
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
