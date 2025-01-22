using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumCsharp.pages;
using System;
namespace SeleniumCsharp.tests
{
    public class Tests

    {
        private string Email = "bara.amarneh@exalt.ps";
        private string Password = "5465123Moaz";


        private IWebDriver driver;
        [OneTimeSetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            driver = new ChromeDriver(path + @"\drivers\", options);

        }
        [Test]
        public void LoginTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.NevgateToPage();
            MyAccountPage myAccountPage = loginPage.Login(Email, Password);
            myAccountPage.VerifyPageTitle();
            myAccountPage.VerifyEmailInPage(Email);
        }
        [TearDown]

        public void TearDown()
        {
            driver.Quit();
        }
    }
}
