using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_web_tests
{
    [TestFixture]
    public class ContactModitificationTests : AuthTestBase
    {
        [Test]
        public void COntactModificationTest()
        {
            ContactData newData = new ContactData("test11");
            newData.LastName = "test12";
            ContactData contact1 = new ContactData("test1");
            contact1.LastName = "test2";

            if (!app.Contact.IsElementPresent(By.ClassName("entry")))
            {
                app.Contact.InitContactCreation();
                app.Contact.FillContactForm(contact1);
                app.Contact.SubmitContactCreation();
                app.Navigator.ReturnToHomePage();
            }
            app.Contact.SelectContact();

            List<ContactData> oldContacts = app.Contact.GetContactList();
            ContactData oldData = oldContacts[1];

            app.Contact.InitContactModification();
            app.Contact.FillContactForm(newData);
            app.Contact.SubmitContactModification();
            app.Navigator.ReturnToHomePage();

            Assert.AreEqual(oldContacts.Count, app.Contact.GetContactCount());

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[1].FirstName = newData.FirstName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.FirstName, contact.FirstName);
                }
            }
        }
    }
}
