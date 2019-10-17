using Homework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace POM.Pages
{
    public  class AutomationPracticeHomePage : BasePage
    {
        private WebDriverWait _wait;
        private IWebDriver _driver;
        

        public AutomationPracticeHomePage(IWebDriver driver)
            : base(driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public void Navigate()
        {

            Driver.Url = "http://automationpractice.com/index.php";
        }

        public IWebElement Logo => _driver.FindElement(By.XPath("//*[@id='block_top_menu']/ul/li[3]/a"));

        public void AssertLink(string expected)
        {

           Assert.AreEqual(expected,Logo.Text);
        }


        public void Maximaze()
        {

            Driver.Manage().Window.Maximize();

        }

       


    }
}
