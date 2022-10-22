using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


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
            app.Groups.SelectGroup(0, newData);

            List<GroupData> oldGroups = app.Groups.GetGroupList();


            app.Groups.RemoveGroup();
            app.Groups.ReturnToGroupsPage();

            List<GroupData> newGroups = app.Groups.GetGroupList();


            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

