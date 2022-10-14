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
    public class AddNewContactTest : TestBase
    {
        [Test]
        public void AddNewUserTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret")); ;
            app.Contact.InitContactCreation();
            ContactData contact = new ContactData("test1");
            contact.LastName = "test2";
            app.Contact.FillContactForm(contact);
            app.Contact.SubmitContactCreation();
            app.Navigator.ReturnToHomePage();
            app.Navigator.Logout();
        }
    }
}

