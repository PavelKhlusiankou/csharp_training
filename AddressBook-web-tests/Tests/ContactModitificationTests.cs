using NUnit.Framework;
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
            ContactData contact = new ContactData("test1");
            contact.LastName = "test2";

            app.Contact.SelectContact(contact);

            List<ContactData> oldContacts = app.Contact.GetContactList();

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
        }
    }
}
