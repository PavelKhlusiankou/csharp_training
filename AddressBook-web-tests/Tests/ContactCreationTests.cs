using System;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AddressBook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void AddNewUserTest()
        {

            ContactData contact = new ContactData("test1");
            contact.LastName = "test2";
            app.Contact.Create(contact);
            app.Navigator.ReturnToHomePage();
        }
    }
}

