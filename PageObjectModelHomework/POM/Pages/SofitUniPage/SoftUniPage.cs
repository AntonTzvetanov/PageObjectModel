using Homework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace POM.Pages
{
    public  class SoftUniPage : BasePage
    {
        

        public SoftUniPage(IWebDriver driver)
            : base (driver)
        {
          

        }

        public void Navigate()
        {

            Driver.Navigate().GoToUrl("https://www.softuni.bg");

        }


        public void Maximaze()
        {

            Driver.Manage().Window.Maximize();

        }

        public void AssertLink(string expected)
        {
           Assert.AreEqual(expected,AssertH1.Text); 
            
        }


        public IWebElement LinkText => Driver.FindElement(By.LinkText("Вход"));

        public IWebElement Username => Driver.FindElement(By.Id("username"));

        public IWebElement Passowrd => Driver.FindElement(By.Id("password"));

        public IWebElement ClickForLoginButton => Driver.FindElement(By.XPath("/html/body/main/div[2]/div/div[2]/div[1]/form/div[4]/input"));

        public IWebElement NavigateToQa => Driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div/div/div[1]/div[1]/div/div[2]/div/ul/li/a"));

        public IWebElement AssertH1  => Driver.FindElement(By.XPath("/html/body/div[2]/header/h1"));

    }
}
