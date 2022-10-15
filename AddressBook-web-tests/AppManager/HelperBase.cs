using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
namespace AddressBook_web_tests
{
    public class HelperBase
    {
        public ApplicationManager manager;
        public IWebDriver driver;

        public HelperBase(ApplicationManager manager) {
            this.manager = manager;
            driver = manager.Driver; 
        }  
    }
}