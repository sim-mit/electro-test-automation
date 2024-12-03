using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FinalProject
{
    internal class OrderReceivedPage
    {
        WebDriverWait driverWait;
        IWebDriver orderReceivedPageDriver;

        public OrderReceivedPage(IWebDriver driver)
        {
            driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            orderReceivedPageDriver = driver;
        }

        By OrderReceivedPageTitle = By.XPath("//h1[contains(text(), \"Order received\")]");

        public void AssertSuccessfullyReceivedOrder()
        {
            driverWait.Until(ExpectedConditions.ElementIsVisible(OrderReceivedPageTitle));

            IWebElement OrderReceivedMessage = orderReceivedPageDriver.FindElement(OrderReceivedPageTitle);

            Assert.That(OrderReceivedMessage.Text, Does.Contain("Order received"));
        }

        public void AssertOrderedProduct()
        {
            string OrderedProduct = orderReceivedPageDriver.FindElement(By.CssSelector("tr.order_item")).Text;

            Assert.That(OrderedProduct, Does.Contain("Tablet Thin EliteBook Revolve 810 G6"));
        }

        public string GetProductOrderNumber()
        {
            string ProductOrderNumber = orderReceivedPageDriver.FindElement(By.CssSelector("li>strong")).Text;

            return ProductOrderNumber;
        }

        By TrackYourOrderButton = By.XPath("//a[@title=\"Track Your Order\"]");

        public void ClickOnTrackYourOrderButton()
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(TrackYourOrderButton)).Click();
        }
    }
}
