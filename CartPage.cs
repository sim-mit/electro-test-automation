using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FinalProject
{
    internal class CartPage
    {
        WebDriverWait driverWait;
        IWebDriver cartPageDriver;

        public CartPage(IWebDriver driver)
        {
            driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            cartPageDriver = driver;
        }

        By ProceedToCheckOutPage = By.CssSelector("a.checkout-button");

        public void ClickOnProceedToCheckOutButton()
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(ProceedToCheckOutPage)).Click();
        }
    }
}
