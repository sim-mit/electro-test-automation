using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FinalProject
{
    internal class MyAccountPage
    {
        WebDriverWait driverWait;
        IWebDriver myAccountPage;

        public MyAccountPage(IWebDriver driver)
        {
            driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            myAccountPage = driver;
        }

        By UserNameOrEmailAddressField = By.CssSelector("input#username");

        public void EnterUserNameOrEmailAddressField()
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(UserNameOrEmailAddressField)).SendKeys("SimonaTest");
        }

        By PasswordField = By.CssSelector("input#password");

        public void EnterPassword()
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(PasswordField)).SendKeys("Brainster123");
        }

        By LoginButton = By.CssSelector("button[name=\"login\"]");

        public void ClickOnLoginButton()
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(LoginButton)).Click();

            string loginMessageText = myAccountPage.FindElement(By.XPath("//strong[text()=\"SimonaM\"]")).Text;
            string pageTitle = myAccountPage.FindElement(By.XPath("//h1[text()=\"My Account\"]")).Text;

            Assert.That("SimonaM", Is.EqualTo(loginMessageText));
            Assert.That("My Account", Is.EqualTo(pageTitle));
        }

        By AccountDetailsButton = By.CssSelector("li.woocommerce-MyAccount-navigation-link--edit-account");

        public void ClickOnAccountDetailsButton()
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(AccountDetailsButton)).Click();
        }

        public void EnterNewPassword()
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(PasswordField)).SendKeys("Brainster456");
        }
    }
}
