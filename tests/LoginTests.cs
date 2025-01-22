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
            MyAccountPage myAccountPage = loginPage.Login("bara.amarneh@exalt.ps", "5465123Moaz");
            myAccountPage.VerifyPageTitle();
            myAccountPage.VerifyEmailInPage("bara.amarneh@exalt.ps");
        }
        [TearDown]

        public void TearDown()
        {
            driver.Quit();
        }
    }
}
