using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
namespace Mantis_tests
{
    public class HelperBase
    {
        public ApplicationManager manager;
        public IWebDriver driver;

        public HelperBase(ApplicationManager manager) {
            this.manager = manager;
            driver = manager.Driver; 
        }
        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;    
            }
            catch (NoSuchElementException)
            {
                return false;   
            }
        }
    }
}