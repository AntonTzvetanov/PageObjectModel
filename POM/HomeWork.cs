using Homework.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POM.Pages;
using System;
using System.IO;
using System.Reflection;

namespace POM
{
    [TestFixture]
    public class Class1
    {
        private ChromeDriver _driver;
        private RegistrationUser _user;
        private RegistrationPage _regPage;
        private LoginPage _loginPage;
        
        [SetUp]

        public void TestInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _loginPage = new LoginPage(_driver);
            
            _user = UserFactory.LoginUser();

            _regPage = new RegistrationPage(_driver);
          
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

        }


        [Test]

        public void GoogleSearchPageObjectModel()
        {

            var search = new GooglePage(_driver);
            search.Maximaze();
            search.Navigate();
            search.SearchForSelenium.SendKeys("selenium");
            search.ClickSearchButton.Click();
            search.AssertLink("Selenium - Web Browser Automation");

        }

        [Test]

        public void SoftUniNavigationPage()
        {
            var _loginToSoftUni = new SoftUniPage(_driver);

            _loginToSoftUni.Navigate();
            _loginToSoftUni.Maximaze();
            _loginToSoftUni.LinkText.Click();
            _loginToSoftUni.Username.SendKeys("TonyCvetanov");
            _loginToSoftUni.Passowrd.SendKeys("PRb7AftzjJ4aaDt");
            _loginToSoftUni.ClickForLoginButton.Click();
            _loginToSoftUni.NavigateToQa.Click();

            _loginToSoftUni.AssertLink("QA Automation - септември 2019");

        }


        [Test]

        public void AutomationPracticeHomePage()
        {
            var loginPage = new AutomationPracticeHomePage(_driver);

            loginPage.Navigate();

            loginPage.AssertLink("T-SHIRTS");

        }

        [Test]

        public void LoginPage()
        {
            var _login = new LoginPage(_driver);

            _login.Navigate();
            _login.Maximaze();
            _login.SignIn.Click();
            _login.Email.SendKeys("test11111@test.bg");
            _login.Submit.Click();
            

        } 

        [Test] 

        public void RegistrationPageSkipFirstName()
        {
           _user.FirstName = "";
            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);
            _regPage.AssertLink("firstname is required.");


        }

        [Test]
        public void FillRegistrationFormWithoutLastName()
        {
            _user.LastName = "";
            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);
            _regPage.AssertLink("lastname is required.");

        }


        [Test]
        public void FillRegistrationFormWithoutPassword()
        {
            _user.Password = "";
            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);
            _regPage.AssertLink("passwd is required.");

        }




        [Test]
        public void FillRegistrationFormWithoutCity()
        {
            _user.City = "";
            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);
            _regPage.AssertLink("city is required.");

        }



        [Test]
        public void FillRegistrationFormWithoutState()
        {
            _user.State= "";
            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);
            _regPage.AssertLink("This country requires you to choose a State.");

        }


        [TearDown]
        public void TearDown()
        {
            var name = TestContext.CurrentContext.Test.Name;
            var result = TestContext.CurrentContext.Result.Outcome;

            if (result == ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                var directory = Directory.GetCurrentDirectory();

                var fullPath = Path.GetFullPath("..\\..\\..\\Screenshots");

                screenshot.SaveAsFile(fullPath + name + ".png", ScreenshotImageFormat.Png);

            }
            _driver.Quit();
        }

    }
}
