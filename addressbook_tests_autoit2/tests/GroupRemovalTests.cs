using NUnit.Framework;
using System;
using System.Collections.Concurrent;


namespace addressbook_tests_autoit2
{
    [TestFixture]
    public class GroupRemovalTestss : TestBase
    {
        [Test]
        public void TestGroupRemove()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove();

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count());
        }
    }
}

