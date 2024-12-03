using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FinalProject
{
    internal class AccountDetailsPage
    {
        WebDriverWait driverWait;
        IWebDriver accountDetailsPageDriver;

        public AccountDetailsPage(IWebDriver driver)
        {
            driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            accountDetailsPageDriver = driver;
        }

        By CurrentPasswordField = By.CssSelector("input#password_current");

        By NewPasswordField = By.CssSelector("input#password_1");

        By ConfirmNewPasswordField = By.CssSelector("input#password_2");

        public void ChangingPassword(string currentPas, string newPass, string confirmNewPass)
        {
            Actions action = new Actions(accountDetailsPageDriver);
            action.MoveToElement(accountDetailsPageDriver.FindElement(CurrentPasswordField)).Perform();
            Thread.Sleep(1000);

            driverWait.Until(ExpectedConditions.ElementToBeClickable(CurrentPasswordField)).SendKeys(currentPas);

            action.MoveToElement(accountDetailsPageDriver.FindElement(NewPasswordField)).Perform();
            Thread.Sleep(1000);

            driverWait.Until(ExpectedConditions.ElementToBeClickable(NewPasswordField)).SendKeys(newPass);

            action.MoveToElement(accountDetailsPageDriver.FindElement(ConfirmNewPasswordField)).Perform();
            Thread.Sleep(1000);

            driverWait.Until(ExpectedConditions.ElementToBeClickable(ConfirmNewPasswordField)).SendKeys(confirmNewPass);
        }

        By SaveChangesButton = By.XPath("//button[@name=\"save_account_details\"]");

        public void ClickOnSaveChangesButton()
        {
            Actions action = new Actions(accountDetailsPageDriver);
            action.MoveToElement(accountDetailsPageDriver.FindElement(SaveChangesButton)).Perform();
            Thread.Sleep(1000);

            driverWait.Until(ExpectedConditions.ElementToBeClickable(SaveChangesButton)).Click();

            IWebElement confirmationMessage = accountDetailsPageDriver.FindElement(By.CssSelector("div.woocommerce-message"));

            action.MoveToElement(confirmationMessage).Perform();
            Thread.Sleep(1000);

            string confirmationMessageText = accountDetailsPageDriver.FindElement(By.CssSelector("div.woocommerce-message")).Text;

            Assert.That("Account details changed successfully.", Does.Contain(confirmationMessageText));
        }

        By LogoutButton = By.CssSelector("li.woocommerce-MyAccount-navigation-link--customer-logout");

        public void ClickOnLogoutButton()
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(LogoutButton)).Click();
        }
    }
}
