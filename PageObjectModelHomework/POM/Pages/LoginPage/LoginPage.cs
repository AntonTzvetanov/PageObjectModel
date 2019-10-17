using Homework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace POM.Pages
{
    public class LoginPage : BasePage
    {
        private WebDriverWait _wait;
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
            : base(driver)

        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));


        }
        public void Navigate()
        {

            Driver.Url = "http://automationpractice.com/index.php?controller=my-account";
        }


        public void Maximaze()
        {

            Driver.Manage().Window.Maximize();

        }

        public IWebElement SignIn => _driver.FindElement(By.XPath("//*[@id='header']/div[2]/div/div/nav/div[1]/a"));

        public IWebElement Email => Driver.FindElement(By.Id("email_create"));

        public IWebElement Submit => Driver.FindElement(By.Id("SubmitCreate"));



    }
}
