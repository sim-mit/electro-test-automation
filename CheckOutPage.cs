using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FinalProject
{
    internal class CheckOutPage
    {
        WebDriverWait driverWait;
        IWebDriver checkOutPageDriver;

        public CheckOutPage(IWebDriver driver)
        {
            driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            checkOutPageDriver = driver;
        }

        By DirectBankTransferButton = By.CssSelector("input#payment_method_bacs");

        public void ClickOnDirectBankTransferButton()
        {
            Actions action = new Actions(checkOutPageDriver);
            action.MoveToElement(checkOutPageDriver.FindElement(DirectBankTransferButton)).Perform();
            Thread.Sleep(1000);

            driverWait.Until(ExpectedConditions.ElementToBeClickable(DirectBankTransferButton)).Click();
        }

        By TermsAndConditionsButton = By.CssSelector("span.woocommerce-terms-and-conditions-checkbox-text");

        public void ClickOnTermsAndConditionsButton()
        {
            Actions action = new Actions(checkOutPageDriver);
            action.MoveToElement(checkOutPageDriver.FindElement(TermsAndConditionsButton)).Perform();
            Thread.Sleep(1000);

            driverWait.Until(ExpectedConditions.ElementToBeClickable(TermsAndConditionsButton)).Click();
        }

        By PlaceOrderButton = By.CssSelector("button#place_order");

        public void ClickOnPlaceOrderButton()
        {
            Actions action = new Actions(checkOutPageDriver);
            action.MoveToElement(checkOutPageDriver.FindElement(PlaceOrderButton)).Perform();
            Thread.Sleep(1000);

            driverWait.Until(ExpectedConditions.ElementToBeClickable(PlaceOrderButton)).Click();
        }
    }
}
