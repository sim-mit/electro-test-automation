using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FinalProject
{
    [TestFixture]
    internal class FinalProjectTests
    {
        IWebDriver driver;

        ElectroPage electroPage;
        MyAccountPage myAccountPage;
        AccountDetailsPage myAccountDetailsPage;
        SearchedProductPage searchedProductPage;
        CartPage cartPage;
        CheckOutPage checkOutPage;
        OrderReceivedPage orderReceivedPage;
        TrackYourOrderPage trackYourOrderPage;

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://electro.madrasthemes.com/");

            electroPage = new ElectroPage(driver);
            myAccountPage = new MyAccountPage(driver);
            myAccountDetailsPage = new AccountDetailsPage(driver);
            searchedProductPage = new SearchedProductPage(driver);
            cartPage = new CartPage(driver);
            checkOutPage = new CheckOutPage(driver);
            orderReceivedPage = new OrderReceivedPage(driver);
            trackYourOrderPage = new TrackYourOrderPage(driver);
        }

        [Test]
        [Order(1)]
        public void ChangePassword()
        {
            electroPage.ClickOnMyAccountButton();

            myAccountPage.EnterUserNameOrEmailAddressField();
            myAccountPage.EnterPassword();
            myAccountPage.ClickOnLoginButton();

            myAccountPage.ClickOnAccountDetailsButton();

            string currentPass = "Brainster123";
            string newPass = "Brainster456";
            string confirmNewPass = "Brainster456";

            myAccountDetailsPage.ChangingPassword(currentPass, newPass, confirmNewPass);
            myAccountDetailsPage.ClickOnSaveChangesButton();

            myAccountDetailsPage.ClickOnLogoutButton();

            myAccountPage.EnterUserNameOrEmailAddressField();
            myAccountPage.EnterNewPassword();
            myAccountPage.ClickOnLoginButton();

            // Changing the password again for the purpose of running the test multiple times
            myAccountPage.ClickOnAccountDetailsButton();
            myAccountDetailsPage.ChangingPassword(newPass, currentPass, currentPass);
            myAccountDetailsPage.ClickOnSaveChangesButton();
        }

        [Test]
        [Order(2)]
        public void TrackOrder()
        {
            electroPage.ClickOnMyAccountButton();

            myAccountPage.EnterUserNameOrEmailAddressField();
            myAccountPage.EnterPassword();
            myAccountPage.ClickOnLoginButton();

            electroPage.SearchKeywordInSearchBar();
            electroPage.ClickOnMagnifierIconOnSearchBar();

            searchedProductPage.AssertCorrectProductsIsDisplayed();

            searchedProductPage.ClickOnAddToCartButton();
            searchedProductPage.ClickOnViewCartButton();

            cartPage.ClickOnProceedToCheckOutButton();

            checkOutPage.ClickOnDirectBankTransferButton();
            checkOutPage.ClickOnTermsAndConditionsButton();
            checkOutPage.ClickOnPlaceOrderButton();

            orderReceivedPage.AssertSuccessfullyReceivedOrder();
            orderReceivedPage.AssertOrderedProduct();
            string orderNumber = orderReceivedPage.GetProductOrderNumber();
            orderReceivedPage.ClickOnTrackYourOrderButton();

            trackYourOrderPage.EnterProductId(orderNumber);
            trackYourOrderPage.EnterBillingEmailAddress();
            trackYourOrderPage.ClickOnTrackButton();
            trackYourOrderPage.VerifyOrderIdAndStatus(orderNumber);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Dispose();
        }
    }
}
