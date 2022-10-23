using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AddressBook_web_tests
{
    
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            ContactData newData = new ContactData("test11");
            newData.LastName = "test12";

            if (!app.Contact.IsElementPresent(By.ClassName("entry")))
            {
                app.Contact.InitContactCreation();
                app.Contact.FillContactForm(newData);
                app.Contact.SubmitContactCreation();
                app.Navigator.ReturnToHomePage();
            }
            app.Contact.SelectContact();

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.RemoveContact();
            app.Contact.ConfirmationOfDeleting();

            //Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactCount());

            List<ContactData> newContacts = app.Contact.GetContactList();

            //ContactData toBeRemoved = oldContacts[0];
            //oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                //Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
