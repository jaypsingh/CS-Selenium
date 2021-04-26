using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit.Abstractions;
using System.Collections.ObjectModel;
using CSSelenium.PageObjectModels;

namespace CSSelenium
{
    public class CSSeleniumPOMDemo
    {
        // below are the links that are used in the demonstrations.
        const string HomeUrl = "https://www.seleniumeasy.com/test/";
        const string sampleAppUrl = "http://uitestingplayground.com/sampleapp";
        const string uiTestPlayUrl = "http://uitestingplayground.com/";
        const string automationPracticeUrl = "http://automationpractice.com/index.php";
        const string basicCalculatorUrl = "https://testsheepnz.github.io/BasicCalculator.html";
        const string progressBarUrl = "http://uitestingplayground.com/progressbar";
        const string PageTitle = "Selenium Easy - Best Demo website to practice Selenium Webdriver Online";

        // This is set to write additional outputs to debug the tests.
        private readonly ITestOutputHelper output;

        /// <summary>
        /// This method is used to demonstrate the use of page object model.
        /// This shows how using page oject model we can do the following:
        /// - Opening Chrome
        /// - Loading a webpage
        /// - Verifying the page title 
        /// - Verifying the page url
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void POMLoadAppPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Navigate().GoToUrl(HomeUrl);
                var homePageHandle = new SeleniumEasyPage(driver);

                //Act


                //Assert
                Assert.Equal(PageTitle, homePageHandle.PageTitle);
                Assert.Equal(HomeUrl, homePageHandle.PageURL);
            }
        }

        ///<summary>
        /// This method is used to demonstrate the use of page object model.
        /// This shows how using page oject model we can do the following:
        /// - Refresh the web page
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void POMRefreshAppPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Navigate().GoToUrl(HomeUrl);
                var homePageHandle = new SeleniumEasyPage(driver);

                //Act
                homePageHandle.RefreshPage();


                //Assert
                Assert.Equal(HomeUrl, homePageHandle.PageURL);
            }
        }


        /// <summary>
        /// This method is used to demonstrate the use of page object model.
        /// This shows how using page oject model we can do the following:
        /// - Going back on the page
        /// - Going forward on the web page
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void GoForwardOnAppPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Navigate().GoToUrl(sampleAppUrl);
                driver.Navigate().GoToUrl(HomeUrl);

                var homePageHandle = new SeleniumEasyPage(driver);

                //Act
                homePageHandle.GoBackOnPage();
                homePageHandle.GoForwardOnPage();

                //Assert
                Assert.Equal(HomeUrl, homePageHandle.PageURL);
            }
        }
    }
}
