using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumCsharp.pages
{
    public class LoginPage
    {
        const string Url = "https://magento.softwaretestingboard.com/customer/account/login/referer";
        IWebDriver _driver;

        [FindsBy(How = How.Name, Using = "login[username]")]
        private IWebElement emailInputField;

        [FindsBy(How = How.Name, Using = "login[password]")]
        private IWebElement passwordField;

        [FindsBy(How = How.CssSelector, Using = "[id=\"login-form\"] button.login")]
        private IWebElement signInBtn;

        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);

        }

        public MyAccountPage Login(string email, string password)
        {
            emailInputField.Clear();
            emailInputField.SendKeys(email);
            passwordField.Clear();
            passwordField.SendKeys(password);
            signInBtn.Click();
            return new MyAccountPage(this._driver);
        }

        public void NevgateToPage()
        {
            this._driver.Navigate().GoToUrl(Url);
        }

    }
}
