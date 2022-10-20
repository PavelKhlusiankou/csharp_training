using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

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
            app.Contact.Remove(1, newData);
        }
    }
}
