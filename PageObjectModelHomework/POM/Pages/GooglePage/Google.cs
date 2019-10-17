using Homework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace POM.Pages
{


    public  class GooglePage : BasePage
    {
        private WebDriverWait _wait;
        private IWebDriver _driver;

        public GooglePage(IWebDriver driver)
            : base(driver)

        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));


        }

        public void Navigate()
        {
            
            Driver.Url = "https://www.google.com";
        }

        public void AssertLink(string expected)
        {

            Assert.AreEqual(expected, AssertLink1.Text);
        }

        public void Maximaze()
        {

           Driver.Manage().Window.Maximize();

        }

        public IWebElement SearchForSelenium => Driver.FindElement(By.Name("q"));

         public IWebElement ClickSearchButton => _wait.Until(d => d.FindElement(By.Name("btnK")));

       

        public IWebElement AssertLink1 => Driver.FindElement(By.XPath("//*[@id='rso']/div[1]/div/div/div/div[1]/a[1]/h3/div"));

        

    }
}
