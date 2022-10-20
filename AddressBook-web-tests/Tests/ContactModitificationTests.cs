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

            app.Contact.Mogify(1, newData, contact);
            app.Navigator.ReturnToHomePage();
        }
    }
}
