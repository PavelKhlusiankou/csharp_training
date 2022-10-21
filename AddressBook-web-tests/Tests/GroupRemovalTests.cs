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
            GroupData group = new GroupData("test1");
            group.Header = "test2";
            group.Footer = "test3";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0, group);

            List<GroupData> newGroups = app.Groups.GetGroupList();


            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

