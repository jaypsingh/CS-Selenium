using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CSSelenium.PageObjectModels;

namespace CSSelenium
{
    public class CSSeleniumPOMDemo
    {
        // below are the links that are used in the demonstrations.
        const string HomeUrl = "https://www.seleniumeasy.com/test/";
        const string PageTitle = "Selenium Easy - Best Demo website to practice Selenium Webdriver Online";

        const string sampleAppUrl = "http://uitestingplayground.com/sampleapp";
        const string uiTestPlayUrl = "http://uitestingplayground.com/";
        const string automationPracticeUrl = "http://automationpractice.com/index.php";
        const string basicCalculatorUrl = "https://testsheepnz.github.io/BasicCalculator.html";
        const string progressBarUrl = "http://uitestingplayground.com/progressbar";

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
                var homePageHandle = new SeleniumEasyPage(driver);                

                //Act
                homePageHandle.Navigate();

                //Assert
                Assert.Equal(PageTitle, homePageHandle.Title);
                Assert.Equal(HomeUrl, homePageHandle.URL);
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
                var homePageHandle = new SeleniumEasyPage(driver);
                homePageHandle.Navigate();

                //Act
                homePageHandle.RefreshPage();

                //Assert
                Assert.Equal(HomeUrl, homePageHandle.URL);
            }
        }


        /// <summary>
        /// This method is used to demonstrate how we can navigate to other page model.
        /// In this test we ate starting from SeleniumEasyPage() page model
        /// and in the run we are transiting to seleniumTutorialPage() model.
        /// This shows how we can do the following:
        /// - Navigate to other page model at run time.
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void GoToSeleniumTutorialPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                var homePageHandle = new SeleniumEasyPage(driver);
                homePageHandle.Navigate();                
                SeleniumTutorialPage seleniumTutorialPage = homePageHandle.ClickSeleniumTutorialLink();
                seleniumTutorialPage.isPageLoaded();
            }
        }
    }
}
