using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FinalProject
{
    internal class ElectroPage
    {
        WebDriverWait driverWait;
        IWebDriver electroPageDriver;

        public ElectroPage(IWebDriver driver)
        {
            driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            electroPageDriver = driver;
        }

        By MyAccountButton = By.CssSelector("i.ec-user");

        public void ClickOnMyAccountButton()
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(MyAccountButton)).Click();
        }

        By SearchBar = By.CssSelector("input#search");

        public void SearchKeywordInSearchBar()
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(SearchBar)).SendKeys("Tablet Thin EliteBook Revolve 810 G6");
        }

        By MagnifierIconOnSearchBar = By.XPath("//button[@type=\"submit\"]");

        public void ClickOnMagnifierIconOnSearchBar()
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(MagnifierIconOnSearchBar)).Click();

            string ProductTitle = electroPageDriver.FindElement(By.CssSelector("h1.product_title")).Text;

            Assert.That("Tablet Thin EliteBook Revolve 810 G6", Is.EqualTo(ProductTitle));
        }
    }
}
