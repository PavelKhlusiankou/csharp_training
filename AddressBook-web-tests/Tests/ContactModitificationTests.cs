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

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Mogify(0, newData, contact);
            app.Navigator.ReturnToHomePage();

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
