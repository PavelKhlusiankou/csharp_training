using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AddressBook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            GroupData newData = new GroupData("test11");
            newData.Header = null;
            newData.Footer = null;


            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsElementPresent(By.Name("selected[]")))
            {
                app.Groups.InitGroupCreation();
                app.Groups.FillGroupForm(newData);
                app.Groups.SubmitGroupCreation();
                app.Groups.ReturnToGroupsPage();
            }
            app.Groups.SelectGroup(0);
            

            List<GroupData> oldGroups = app.Groups.GetGroupList();


            app.Groups.RemoveGroup();
            app.Groups.ReturnToGroupsPage();

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}

