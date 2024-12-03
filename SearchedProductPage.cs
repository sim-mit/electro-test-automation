using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FinalProject
{
    internal class SearchedProductPage
    {
        WebDriverWait driverWait;
        IWebDriver searchedProductDriver;

        public SearchedProductPage(IWebDriver driver)
        {
            driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            searchedProductDriver = driver;
        }

        public void AssertCorrectProductsIsDisplayed()
        {
            string ProductTitle = searchedProductDriver.FindElement(By.CssSelector("h1.product_title")).Text;

            Assert.That("Tablet Thin EliteBook Revolve 810 G6", Is.EqualTo(ProductTitle));
        }

        By AddToCartButton = By.CssSelector("button.single_add_to_cart_button");

        public void ClickOnAddToCartButton()
        {
            Actions action = new Actions(searchedProductDriver);
            action.MoveToElement(searchedProductDriver.FindElement(AddToCartButton)).Perform();
            Thread.Sleep(1000);

            driverWait.Until(ExpectedConditions.ElementToBeClickable(AddToCartButton)).Click();

            string ProductAddedToCartMessage = searchedProductDriver.FindElement(By.CssSelector("div.woocommerce-message")).Text;

            Assert.That(ProductAddedToCartMessage, Does.Contain("“Tablet Thin EliteBook Revolve 810 G6” has been added to your cart."));
        }

        By ViewCartButton = By.CssSelector("a[tabindex=\"1\"]");

        public void ClickOnViewCartButton()
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(ViewCartButton)).Click();
        }
    }
}
