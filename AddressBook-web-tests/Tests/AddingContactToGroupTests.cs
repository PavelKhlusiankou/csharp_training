using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AddressBook_web_tests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            ContactData contact1 = new ContactData("test1");
            contact1.LastName = "test2";
            GroupData group1 = new GroupData("test1");
            group1.Header = "test2";
            group1.Footer = "test3";

            app.Contact.IsContactsExist(contact1);

            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsElementPresent(By.Name("selected[]")))
            {
                app.Groups.InitGroupCreation();
                app.Groups.FillGroupForm(group1);
                app.Groups.SubmitGroupCreation();
                app.Navigator.GoToHomePage();
            }
            app.Contact.SearchingContactsWithoutGroups(contact1);


            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(group.GetContacts()).First();

             app.Contact.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }

        [Test]
        public void TestRemovingContactFromGroup()
        {
            ContactData contact1 = new ContactData("test1");
            contact1.LastName = "test2";
            GroupData group1 = new GroupData("test1");
            group1.Header = "test2";
            group1.Footer = "test3";


            

            app.Contact.IsContactsExist(contact1);

            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsElementPresent(By.Name("selected[]")))
            {
                app.Groups.InitGroupCreation();
                app.Groups.FillGroupForm(group1);
                app.Groups.SubmitGroupCreation();
                app.Navigator.GoToHomePage();
            }
            app.Contact.SearchingContactsWithoutGroups(contact1);

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(group.GetContacts()).First();

            app.Contact.SearchingContactsInGroups(group);

            app.Contact.RemoveContactFromGroup( group);

            List<ContactData> newList = group.GetContacts();
            oldList.RemoveAt(0);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
