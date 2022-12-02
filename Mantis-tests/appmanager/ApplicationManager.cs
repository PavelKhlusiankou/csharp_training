using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;

namespace Mantis_tests
{
    public class ApplicationManager
    {
        public IWebDriver driver;
        public string baseURL;

        public RegistrationHelper Registration { get; set; }

        public FtpHelper Ftp { get; set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
        public LoginHelper loginHelper;

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-2.25.4";
            //Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            loginHelper = new LoginHelper(this);
        }

        [TearDown]
            ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-2.25.4/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }


        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

    }
}
