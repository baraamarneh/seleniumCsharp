
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumCsharp.pages
{
    class MyAccountPage
    {
        const string Url = "https://magento.softwaretestingboard.com/customer/account/";
        const string Title = "My Account";
        IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = ".block.block-dashboard-info .box-content p")]
        IWebElement fullName;
        public MyAccountPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void VerifyPageTitle()
        {
            ClassicAssert.AreEqual(Title, this.driver.Title);
            Console.WriteLine(fullName.Text);

        }

        public void VerifyEmailInPage(string email)
        {
            ClassicAssert.IsTrue(fullName.Text.Contains(email));
        }
    }
}
