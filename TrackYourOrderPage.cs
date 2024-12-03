using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FinalProject
{
    internal class TrackYourOrderPage
    {
        WebDriverWait driverWait;
        IWebDriver trackYourOrderPageDriver;

        public TrackYourOrderPage(IWebDriver driver)
        {
            driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            trackYourOrderPageDriver = driver;
        }

        By OrdeIdField = By.CssSelector("input#orderid");

        public void EnterProductId(string orderNumber)
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(OrdeIdField)).SendKeys(orderNumber);
        }

        By BillingEmailAddressField = By.CssSelector("input#order_email");

        public void EnterBillingEmailAddress()
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(BillingEmailAddressField)).SendKeys("testsimona@test.com");
        }

        By TrackButton = By.CssSelector("button.button");

        public void ClickOnTrackButton()
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(TrackButton)).Click();
        }

        public void VerifyOrderIdAndStatus(string orderNumber)
        {
            string orderId = trackYourOrderPageDriver.FindElement(By.CssSelector("mark.order-number")).Text;
            string orderStatus = trackYourOrderPageDriver.FindElement(By.CssSelector("mark.order-status")).Text;

            Assert.That(orderNumber, Is.EqualTo(orderId));
            Assert.That(orderStatus, Is.EqualTo("On hold"));
        }
    }
}