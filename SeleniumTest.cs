using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
namespace SeleniumCsharp
{
    public class Tests

    {
        IWebDriver driver;
        [OneTimeSetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            this.driver = new ChromeDriver(path + @"\drivers\", options);
            driver.Url = "https://demoqa.com/browser-windows/";
            driver.Navigate().GoToUrl(driver.Url);

        }
        [Test]
        public void verifyLogo()
        {
            var elementNewButton = driver.FindElement(By.Id("tabButton"));
            String windowTitle = driver.WindowHandles.Last();
            Console.WriteLine(windowTitle);

            for (var i = 0; i < 3; i++)
            {
                elementNewButton.Click();
                Thread.Sleep(3000);
            }


            List<string> listOfWindowStrings= driver.WindowHandles.ToList();
            foreach(var handle in  listOfWindowStrings) {
            driver.SwitchTo().Window(handle);
                driver.Navigate().GoToUrl("https://www.facebook.com/");
                driver.Close();
                driver.Navigate().GoToUrl("https://www.facebook.com/");

            }



            //driver.Navigate().GoToUrl(driver.Url);
            //driver.FindElement(By.CssSelector("a[href=\"#enroll-form\"]")).Click();
            //IWebElement firstNameInputField = driver.FindElement(By.Id("first-name"));
            //IWebElement submitFormBtn = driver.FindElement(By.ClassName("btn-primary"));
            //Console.WriteLine(submitFormBtn.Displayed);
            //Console.WriteLine(submitFormBtn.GetCssValue("background-color"));
            //Console.WriteLine(submitFormBtn.Size.Width+", "+submitFormBtn.Size.Height);
            //Console.WriteLine(submitFormBtn.Location.X + ", " + submitFormBtn.Location.Y);

            //firstNameInputField.SendKeys("Bara");
            //submitFormBtn.Click();



            //driver.Quit();


        }
    }
}
