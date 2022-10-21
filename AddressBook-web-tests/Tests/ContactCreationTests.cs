using System;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace AddressBook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void AddNewUserTest()
        {

            ContactData contact = new ContactData("test1");
            contact.LastName = "test2";

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(contact);
            app.Navigator.ReturnToHomePage();

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

