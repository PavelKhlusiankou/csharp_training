﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit2
{
    public class TestBase
    {
        public ApplicationManager app;

        [SetUp]
        public void initApplication()
        {
            app = new ApplicationManager();
        }
        [TearDown]
        public void stopApplication()
        {
            app.Stop();
        }
    }
}
