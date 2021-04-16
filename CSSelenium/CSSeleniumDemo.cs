using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit.Sdk;

namespace CSSelenium
{
    public class CSSeleniumDemo
    {
        string HomeUrl = "https://www.seleniumeasy.com/test/";
        string sampleAppUrl= "http://uitestingplayground.com/sampleapp";
        string uiTestPlayUrl = "http://uitestingplayground.com/";
        string PageTitle = "Selenium Easy - Best Demo website to practice Selenium Webdriver Online";
        
        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadAppPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Navigate().GoToUrl(HomeUrl);

                //Act
                

                //Assert
                Assert.Equal(PageTitle, driver.Title);
                Assert.Equal(HomeUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void RefreshAppPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Navigate().GoToUrl(HomeUrl);

                //Act
                driver.Navigate().Refresh();


                //Assert
                Assert.Equal(HomeUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void GoBackOnAppPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Navigate().GoToUrl(HomeUrl);
                driver.Navigate().GoToUrl(sampleAppUrl);

                //Act
                driver.Navigate().Back();

                //Assert
                Assert.Equal(HomeUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void GoForwardOnAppPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Navigate().GoToUrl(sampleAppUrl);
                driver.Navigate().GoToUrl(HomeUrl);                

                //Act
                driver.Navigate().Back();
                driver.Navigate().Forward();

                //Assert
                Assert.Equal(HomeUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void FindElementByID()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange                
                driver.Navigate().GoToUrl(sampleAppUrl);
                
                var expectedElementText = "Log In";

                //Act
                IWebElement webElement = driver.FindElement(By.Id("login"));
                var actualElemntText = webElement.Text;

                //Assert
                Assert.Equal(expectedElementText, actualElemntText);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ClickOnElementByID()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange                
                driver.Navigate().GoToUrl(sampleAppUrl);

                var expectedElementText = "Invalid username/password";

                //Act
                IWebElement loginButton = driver.FindElement(By.Id("login"));
                loginButton.Click();

                IWebElement loginStatusMessage = driver.FindElement(By.Id("loginstatus"));
                var actualElement = loginStatusMessage.Text;

                //Assert
                Assert.Equal(expectedElementText, actualElement);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ClickOnElementByLinkText()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange                
                driver.Navigate().GoToUrl(uiTestPlayUrl);
                var expectedPageTitle = "Dynamic ID";

                //Act
                IWebElement linkText = driver.FindElement(By.LinkText("Dynamic ID"));
                linkText.Click();

                var actualPageTitle = driver.Title;

                //Assert
                Assert.Equal(expectedPageTitle, actualPageTitle);
            }
        }
    }
}
